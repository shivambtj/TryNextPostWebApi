using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IUserPermissionMasterService
    {
        Task<Tuple<int, string>> saveUserPermissiondata(UserPermissionMasterDto userPermissionMasterDto);
        Task<Tuple<int, string>> updateUserPermissiondata(UserPermissionMasterDto userPermissionMasterDto);
    }
}
