using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Utilities.Zlib;
using System.ComponentModel.DataAnnotations;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Services
{
    public class UserPermissionMasterService : IUserPermissionMasterService
    {
        private readonly AppDbContext _appDbContext;
        public UserPermissionMasterService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Tuple<int,string>> saveUserPermissiondata(UserPermissionMasterDto userPermissionMasterDto )
        {
            try
            {
                var exists = await _appDbContext.userPermissions
                .AnyAsync(x => x.MenuId == userPermissionMasterDto.MenuId
                && x.RoleId == userPermissionMasterDto.RoleId);

                if (exists)
                {
                    return new Tuple<int, string>(0, "Menu permission for this role already exists.");
                }
                _appDbContext.userPermissions.Add(new Entities.UserPermissionMaster
                {
                    MenuId = userPermissionMasterDto.MenuId,
                    RoleId = userPermissionMasterDto.RoleId,
                    Add = userPermissionMasterDto.Add,
                    Edit = userPermissionMasterDto.Edit,
                    Delete = userPermissionMasterDto.Delete,
                    View = userPermissionMasterDto.View
                });

                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Permission saved successfully.");
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        public async Task<Tuple<int,string>> updateUserPermissiondata(UserPermissionMasterDto userPermissionMasterDto)
        {
            try
            {
                var exists = await _appDbContext.userPermissions
     .FirstOrDefaultAsync(x => x.MenuId == userPermissionMasterDto.MenuId
                 && x.RoleId == userPermissionMasterDto.RoleId
                 && x.UserPermissionId != userPermissionMasterDto.UserPermissionId);

                if (exists==null)
                {
                    return new Tuple<int, string>(1, "Menu permission for this role already exists.");
                }
                exists.RoleId = userPermissionMasterDto.RoleId;
                exists.MenuId= userPermissionMasterDto.MenuId;
                exists.Add = userPermissionMasterDto.Add;
                exists.Edit= userPermissionMasterDto.Edit;
                exists.Delete= userPermissionMasterDto.Delete;
                exists.View = userPermissionMasterDto.View;
                _appDbContext.Update(exists);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(2,"User Permission Data Update Sucessfully");
            }
            catch(Exception ex)
            {
                return new Tuple<int,string>(-1, ex.Message);
            }
        }
    }

}
