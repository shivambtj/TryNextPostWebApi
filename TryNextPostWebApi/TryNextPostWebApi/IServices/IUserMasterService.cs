using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IUserMasterService
    {
        Task<Tuple<int, string>> SaveUserData(UserMasterDto userMasterDto);
    }
}
