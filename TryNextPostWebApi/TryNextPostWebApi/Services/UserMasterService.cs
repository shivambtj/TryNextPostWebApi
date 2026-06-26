using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Services
{
    public class UserMasterService : IUserMasterService
    {
        private readonly AppDbContext _appDbContext;
        public UserMasterService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Tuple<int,string>> SaveUserData(UserMasterDto userMasterDto)
        {
            try
            {
                var exitsUser= await _appDbContext.UserMasters.FirstOrDefaultAsync(x => x.EmailId == userMasterDto.EmailId);
                if(exitsUser != null)
                {
                    return new Tuple<int, string>(0, "User already exists!!");
                }
                
                return new Tuple<int, string>(1, "User data Save sucessfully!!");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message); 
            }
        }
    }
}
