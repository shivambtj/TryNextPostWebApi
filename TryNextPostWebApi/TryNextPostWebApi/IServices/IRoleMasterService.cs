using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IRoleMasterService
    {
        Task<Tuple<int, string>> SaveRoleData(RoleMasterDto roleMasterDto);
        Task<Tuple<int, string>> UpdateRoleData(RoleMasterDto roleMasterDto);
        Task<Tuple<int, RoleMasterDto>> GetRoleDataById(int roleId);
        Task<Tuple<int, List<RoleMasterDto>>> getAllData();
        Task<Tuple<int, string>> RemoveMailSettingById(int id);
    }
}
