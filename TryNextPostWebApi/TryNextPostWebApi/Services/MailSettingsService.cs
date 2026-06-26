using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.Entities;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Services
{
    public class MailSettingsService : IMailSettingsService
    {
        private readonly AppDbContext _appDbContext;
        public MailSettingsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Tuple<int,string>> SaveMailData(MailSettingsDto mailSettingsDto)
        {
            try
            {
                var exitsMail= await _appDbContext.MailSettings.AnyAsync(x=>x.FromMailAdress== mailSettingsDto.FromMailAdress);
                if(exitsMail == null)
                {
                    return new Tuple<int, string>(0, "Email Address Already Exits Please try Anothor Mail Address");
                }
                _appDbContext.MailSettings.Add(new Entities.MailSettings
                {
                    SmtpServer=mailSettingsDto.SmtpServer,
                    Port=mailSettingsDto.Port,
                    FromMailAdress=mailSettingsDto.FromMailAdress,
                    Password=mailSettingsDto.Password,
                    ToMailAddress=mailSettingsDto.ToMailAddress,
                    CCMailAddress=mailSettingsDto.CCMailAddress,
                    BCCMailAddress=mailSettingsDto.BCCMailAddress,
                    Subjects=mailSettingsDto.Subjects,
                    MessageBody=mailSettingsDto.MessageBody,
                    MailFor=mailSettingsDto.MailFor,
                    CreatedBy="Admin",
                    CreatedOn= DateTime.UtcNow
                });
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Mail data saved sucessfully");
            }
            catch (Exception ex)
            {
            return new Tuple<int,string>(-1, ex.Message);
            }
        }
        public async Task<Tuple<int,string>> UpdateMailData(MailSettingsDto mailSettingsDto)
        {
            try
            {
                var exitsMailId = await _appDbContext.MailSettings.FirstOrDefaultAsync(x => x.MailSettingsId == mailSettingsDto.MailSettingsId);
                if(exitsMailId.MailSettingsId==null)
                {
                    return new Tuple<int, string>(0, "Mail Address not found");
                }

                exitsMailId.SmtpServer = mailSettingsDto.SmtpServer;
                exitsMailId.Port = mailSettingsDto.Port;
                exitsMailId.FromMailAdress = mailSettingsDto.FromMailAdress;
                exitsMailId.Password = mailSettingsDto.Password;
                exitsMailId.ToMailAddress = mailSettingsDto.ToMailAddress;
                exitsMailId.CCMailAddress = mailSettingsDto.CCMailAddress;
                exitsMailId.BCCMailAddress = mailSettingsDto.BCCMailAddress;
                exitsMailId.Subjects = mailSettingsDto.Subjects;
                exitsMailId.MessageBody = mailSettingsDto.MessageBody;
                exitsMailId.MailFor = mailSettingsDto.MailFor;
                exitsMailId.UpdatedBy = "Admin";
                exitsMailId.UpdatedOn = DateTime.UtcNow;
                
                _appDbContext.Update(exitsMailId);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Mail data has been sucessfully Updated");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        public async Task<Tuple<int,MailSettingsDto>> GetDataById(long id)
        {
            try
            {
                var result = await _appDbContext.MailSettings.AsNoTracking().Where(x => x.MailSettingsId == id).Select(x => new MailSettingsDto
                {
                    MailSettingsId = x.MailSettingsId,
                    SmtpServer = x.SmtpServer,
                    Port = x.Port,
                    FromMailAdress = x.FromMailAdress,
                    Password = x.Password,
                    ToMailAddress = x.ToMailAddress,
                    CCMailAddress = x.CCMailAddress,
                    BCCMailAddress = x.CCMailAddress,
                    Subjects = x.Subjects,
                    MessageBody = x.MessageBody,
                    MailFor = x.MailFor,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).FirstOrDefaultAsync();
                if(result==null)
                {
                    return new Tuple<int, MailSettingsDto>(0, null);
                }
                return new Tuple<int, MailSettingsDto>(1, result);
            }catch(Exception ex)
            {

                return new Tuple<int, MailSettingsDto>(-1, new MailSettingsDto());
            }
        }
        public async Task<Tuple<int,List<MailSettingsDto>>> getAllData()
        {
            try
            {
                var result = await _appDbContext.MailSettings.Select(x => new MailSettingsDto
                {
                    MailSettingsId = x.MailSettingsId,
                    SmtpServer = x.SmtpServer,
                    Port = x.Port,
                    FromMailAdress = x.FromMailAdress,
                    Password = x.Password,
                    ToMailAddress = x.ToMailAddress,
                    CCMailAddress = x.CCMailAddress,
                    BCCMailAddress = x.CCMailAddress,
                    Subjects = x.Subjects,
                    MessageBody = x.MessageBody,
                    MailFor = x.MailFor,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).ToListAsync();
                if (result == null)
                {
                    return new Tuple<int, List<MailSettingsDto>>(0, null);
                }
                return new Tuple<int, List<MailSettingsDto>>(1, result);
            }
            catch(Exception ex)
            {
                return new Tuple<int, List<MailSettingsDto>>(-1, null);
            }
        }
        public async Task<Tuple<int,String>> removeDataById(long id)
        {
            try
            {
                var mailId = await _appDbContext.MailSettings.FirstOrDefaultAsync(x => x.MailSettingsId == id);
                if(mailId==null)
                {
                    return new Tuple<int, string>(0, "data not found");
                }
                _appDbContext.Remove(mailId);
                await _appDbContext.SaveChangesAsync(); 
                return new Tuple<int, string>(1, "data removed Sucessfully");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
    }
}

