using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IMenueItemMasterService
    {
        Task<Tuple<int, string>> saveMenuedata(MenueItemMasterDto menueItemMasterDto);
    }
}
