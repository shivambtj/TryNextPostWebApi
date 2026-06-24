using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;
namespace TryNextPostWebApi.Services

{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly ExcelLoginLogger _logger;
        private readonly INotificationService _notificationService;
        public AuthService(AppDbContext Context, ExcelLoginLogger logger, IConfiguration configuration, INotificationService notificationService)
        {
            _appDbContext = Context;
            _logger = logger;
            _configuration = configuration;
            _notificationService = notificationService;
        }
        //=======================start User login =========================
        public async Task<Tuple<int,TokenDto>> Login(UserMasterDto userMasterDto)
        {
            var tokenDto = new TokenDto();
            try
            {
                
                if(userMasterDto==null)
                {
                    tokenDto.Token = string.Empty;
                    tokenDto.Message = "Please fill All the details!!";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId, "Request Empty");
                    return new Tuple<int, TokenDto>(0, tokenDto);
                }
                //===========================user exits or not============================
                var exitsUser = await _appDbContext.UserMasters.FirstOrDefaultAsync(x=>x.EmailId == userMasterDto.EmailId);
                if(exitsUser == null)
                {

                    tokenDto.Token = string.Empty;
                    tokenDto.Message = "This User Not Exist. Please Login Agian!!";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "This User Not Exist");
                    return new Tuple<int, TokenDto>(1, tokenDto);
                }
                //===========================user Active or not =========================
                if (exitsUser.UserStatus == "N")
                {
                    tokenDto.Token = string.Empty;
                    tokenDto.Message = "User is not active. Please contact admin.";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "User is not active."); 
                    return new Tuple<int, TokenDto>(6, tokenDto);
                }
                //====================uyser Password Expired or not =========================
                if (exitsUser.PasswordValidity < DateTime.UtcNow)
                {
                    tokenDto.Token = string.Empty;
                    tokenDto.Message = "Password expired. Please reset your password.";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "Password expired."); 
                    return new Tuple<int, TokenDto>(7, tokenDto);
                }
                var passwordHash = new PasswordHasher<string>();
                var verifyPassword = passwordHash.VerifyHashedPassword(userMasterDto.EmailId, exitsUser.Password, userMasterDto.Password);
                //==================password matched =========================
                if (verifyPassword== PasswordVerificationResult.Success)
                {
                    UserMasterDto user = new();
                    user.UserId = exitsUser.UserId;
                    user.UserName = exitsUser.UserName;
                    user.EmailId = exitsUser.EmailId;
                    var token = GetJwtToken(user);
                    tokenDto.Token = token;
                    tokenDto.Message = $"Welocome {exitsUser.UserName} Login Successfully!!Your Password Expired Within 6 Month!!!";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "Login Successfully");
                    return new Tuple<int, TokenDto>(2, tokenDto);
                }
                //==================password matched but need to rehash =========================
                else if (verifyPassword == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    UserMasterDto user = new();
                    user.UserId = exitsUser.UserId;
                    user.UserName = exitsUser.UserName;
                    user.EmailId = exitsUser.EmailId;
                    var token = GetJwtToken(user);
                    exitsUser.Password = PasswordHashing(userMasterDto);
                    _appDbContext.UserMasters.Update(exitsUser);
                    await _appDbContext.SaveChangesAsync();
                    tokenDto.Token = token;
                    tokenDto.Message = "User Login Sucessfull, New hash Generated";
                    return new Tuple<int,TokenDto>(3, tokenDto);
                }
                //==================password not matched =========================
                else if (verifyPassword == PasswordVerificationResult.Failed)
                {
                    tokenDto.Message = "Password Incorrect, Please try agian";
                    await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "Password Incorrect"); 
                    return new Tuple<int, TokenDto>(4, tokenDto);
                }
                tokenDto.Message = "user not exits please login";
                await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "user not exits please login"); 
                return new Tuple<int, TokenDto>(5, tokenDto);
            }
            catch(Exception ex)
            {
                tokenDto.Message = ex.Message;
                await _logger.LogAsync(userMasterDto.UserName, userMasterDto.EmailId,  "An error occurred while processing the login request.");
                return new Tuple<int, TokenDto>(-1, tokenDto);


            }
        }
        //=======================End User login =========================

        //============================start User logout ===========================
        public async Task<Tuple<int, string>> Logout(UserMasterDto userMasterDto)
        {
            try
            {
                // Update Logout Time in Excel
                await _logger.UpdateLogoutTimeAsync(userMasterDto.EmailId);

                await _logger.LogAsync(
                    userMasterDto.UserName,
                    userMasterDto.EmailId,
                    "Logout Successfully"
                );

                return new Tuple<int, string>(2, "Logout Successful");
            }
            catch (Exception ex)
            {
                await _logger.LogAsync(
                    userMasterDto.UserName,
                    userMasterDto.EmailId,
                    "Logout Error: " + ex.Message
                );

                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        //============================end user logout================================
        //=======================Start User Registration =========================
        public async Task<Tuple<int,string>> UserRegister(UserMasterDto userMasterDto)
        {
            try
            {
                //====1. Check if user already exists with the same email or phone number
                var existingUser = await _appDbContext.UserMasters.AnyAsync(x => x.EmailId == userMasterDto.EmailId);
                //if (existingUser)
                //{
                //    return new Tuple<int, string>(0, "This User Alredy Exits. Please login with diffrent Email!!!!");
                //}
                _ = _appDbContext.UserMasters.Add(new Entities.UserMaster
                {
                    UserName = userMasterDto.UserName,
                    EmailId = userMasterDto.EmailId,
                    Password = PasswordHashing(userMasterDto),
                    PhoneNumber = userMasterDto.PhoneNumber,
                    BusinessName = userMasterDto.BusinessName,
                    BrandName = userMasterDto.BrandName,
                    RoleId=1,
                    PasswordValidity = DateTime.UtcNow.AddMonths(6),
                    UserStatus = "Y",
                    CreatedBy = "",
                    CreatedOn = DateTime.UtcNow

                });
                //=============for send mail to registered user =========================
                var mailResult = await _notificationService.SendAsync(userMasterDto.EmailId,userMasterDto.UserName);

                //=============end send mail to registered user =========================
               if(mailResult.Item1==1)
                {
                    await _appDbContext.SaveChangesAsync();
                    return new Tuple<int, string>(1, "User Registered Sucessfully!!");
                }
               else
                {
                    return new Tuple<int, string>(-1, "User Registered  not Sucessfully!!");
                }
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(3, ex.Message);
            }
        }
        //=======================end User Registration =========================
        //=====================start JWT Token=========================
        private string GetJwtToken(UserMasterDto userMasterDto)
        {
            var claim = new[]
            {
                new Claim(ClaimTypes.Name, userMasterDto.UserName),
                new Claim(ClaimTypes.Email, userMasterDto.EmailId),
                new Claim(ClaimTypes.NameIdentifier, userMasterDto.UserId.ToString())
            };
            var key= new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
       issuer: _configuration["Jwt:Issuer"],
       audience: _configuration["Jwt:Audience"],
       claims: claim,
       expires: DateTime.UtcNow.AddMinutes(10),
       signingCredentials: credentials
   );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //=====================end JWT Token=========================
        //=======================start Password Hashing (Encryption)=========================
        private string PasswordHashing(UserMasterDto userMasterDto)
        {
           var PasswordHasher= new PasswordHasher<string>();
            var hash= PasswordHasher.HashPassword(userMasterDto.EmailId, userMasterDto.Password);
            return hash;

        }
        //=======================End Password Hashing =========================
    }
}
