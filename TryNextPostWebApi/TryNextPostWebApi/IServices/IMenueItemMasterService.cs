using TryNextPostWebApi.Dto;

namespace TryNextPostWebApi.IServices
{
    public interface IMenueItemMasterService
    {
        Task<Tuple<int, string>> saveMenuedata(MenueItemMasterDto menueItemMasterDto);
        Task<Tuple<int, string>> updateMenueData(MenueItemMasterDto menueItemMasterDto);
        Task<Tuple<int, MenueItemMasterDto>> GetMenueById(int id);
        Task<Tuple<int, List<MenueItemMasterDto>>> getAllMenueData();
        Task<Tuple<int, string>> removeMenuById(int id);
    }
}
