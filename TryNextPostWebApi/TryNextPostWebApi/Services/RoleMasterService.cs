using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Services
{
    public class RoleMasterService : IRoleMasterService
    {
        private readonly AppDbContext _appDbContext;
        public RoleMasterService(AppDbContext appDbContext)        {
            _appDbContext = appDbContext;
        }
        //===================start save role data =========================
        public async Task<Tuple<int,string>> SaveRoleData(RoleMasterDto roleMasterDto)
        {
            try
            {
                var exitsRole = await _appDbContext.RoleMasters.AnyAsync(x => x.RoleName == roleMasterDto.RoleName);
                if(exitsRole)
                {
                    return new Tuple<int, string>(0, "Role already exits.");
                }
                _appDbContext.RoleMasters.Add(new Entities.RoleMaster
                {
                    RoleName= roleMasterDto.RoleName,
                    CreatedBy="admin",
                    CreatedOn= DateTime.UtcNow
                });
                 await _appDbContext.SaveChangesAsync();
                return new Tuple<int,string>(1, "Role data saved successfully.");
            }
            catch (Exception ex)
            {
                
                return new Tuple<int,string>(-1, $"Error saving role data: {ex.Message}");
            }
        }
        //===================end save role data ===========================================================
        //===================start update role data =======================================================

        public async Task<Tuple<int, string>> UpdateRoleData(RoleMasterDto roleMasterDto)
        {
            try
            {
                var roleMasterData = await _appDbContext.RoleMasters.FirstOrDefaultAsync(x => x.RoleId == roleMasterDto.RoleId);
                if(roleMasterData == null)
                {
                    return new Tuple<int, string>(0, "Role not exits.");
                }
                else
                {
                    roleMasterData.RoleName = roleMasterDto.RoleName ?? "";
                    roleMasterData.UpdatedBy = "admin1";
                    roleMasterData.UpdatedOn = DateTime.UtcNow;
                    _appDbContext.Update(roleMasterData);
                    await _appDbContext.SaveChangesAsync();
                    return new Tuple<int, string>(1, "Role data updated successfully.");
                }

            }
            catch (Exception ex)
            {

                return new Tuple<int, string>(-1, $"Error saving role data: {ex.Message}");
            }
        }
        //==================end update role data =========================
        //===========================start get role data access by id=======================
        public async Task<Tuple<int,RoleMasterDto>> GetRoleDataById(int roleId)
        {
           
            try
            {
                var roleData = await _appDbContext.RoleMasters.AsNoTracking().Where(x => x.RoleId == roleId).Select(x => new RoleMasterDto
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    CreatedBy=x.CreatedBy,
                    CreatedOn=x.CreatedOn,
                    UpdatedBy=x.UpdatedBy,
                    UpdatedOn= x.UpdatedOn
                    
                }).FirstOrDefaultAsync();
              if(roleData == null)
                {
                    return new Tuple<int, RoleMasterDto>(0,null);
                }
                return new Tuple<int, RoleMasterDto>(1, roleData);
            }
            catch (Exception ex)
            {
                return new Tuple<int, RoleMasterDto>(1, new RoleMasterDto());
            }
        }
        //===========================end role data access by id ================================
        //============================start fetch all data from database========================
        public async Task<Tuple<int,List<RoleMasterDto>>> getAllData()
        {
            try
            {
                var result = await _appDbContext.RoleMasters
            .Select(x => new RoleMasterDto
            {
                RoleId = x.RoleId,
                RoleName = x.RoleName,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            })
            .ToListAsync();
                if (result==null)
                {
                    return new Tuple<int, List<RoleMasterDto>>(0, null);
                }
                return new Tuple<int, List<RoleMasterDto>>(1, result);
            }
            catch(Exception ex)
            {
                return new Tuple<int, List<RoleMasterDto>>(-1, null);
            }
        }
        //==========================end fetch all data from database =========================== 
        //===============================start remove data using id =====================================
        public async Task<Tuple<int,string>> RemoveMailSettingById(int id)
        {
            try
            {
                var roleId = await _appDbContext.RoleMasters.FirstOrDefaultAsync(x=>x.RoleId==id);
                if(roleId==null)
                {
                    return new Tuple<int, string>(0, "data not found");
                }
                _appDbContext.Remove(roleId);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Role data removed sucessfully");

            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        //==============================end remove data using id=======================================
    }
}
