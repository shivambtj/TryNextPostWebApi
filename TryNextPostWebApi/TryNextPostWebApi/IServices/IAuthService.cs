using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IAuthService
    {
        Task<Tuple<int, TokenDto>> Login(UserMasterDto userMasterDto);
        Task<Tuple<int, string>> Logout(UserMasterDto userMasterDto);
        Task<Tuple<int, string>> UserRegister(UserMasterDto userMasterDto);
        Task<Tuple<int, string>> ForgetPasswordAsync(string emailId);
        Task<Tuple<int, string>> verifyPassword(string otp);
        Task<Tuple<int, string>> NewPassword(UserMasterDto userMasterDto);
    }
}
