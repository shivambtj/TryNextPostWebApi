using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.Entities;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Services
{
    public class MenueItemMasterService : IMenueItemMasterService
    {
        private readonly AppDbContext _appDbContext;
        public MenueItemMasterService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Tuple<int,string>> saveMenuedata(MenueItemMasterDto menueItemMasterDto)
        {
            try
            {
                var exitsMenue = await _appDbContext.MenueItemMaster.FirstOrDefaultAsync(x=>x.Title == menueItemMasterDto.Title);
            if(exitsMenue != null)
                {
                    return new Tuple<int, string>(0, "menue title already exits.");
                }
                _appDbContext.MenueItemMaster.Add(new Entities.MenueItemMaster
                {
                    ParentId=menueItemMasterDto.ParentId,
                    Title = menueItemMasterDto.Title,
                    Url=menueItemMasterDto.Url,
                    Description=menueItemMasterDto.Description,
                    CssClass = menueItemMasterDto.CssClass,
                    CreatedBy="Admin",
                    CreatedOn = DateTime.UtcNow
                });
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Menue Data Saved SucessFully");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        public async Task<Tuple<int,string>> updateMenueData(MenueItemMasterDto menueItemMasterDto)
        {
            try
            {
                var exitsMenue = await _appDbContext.MenueItemMaster.FirstOrDefaultAsync(x => x.MenueItemId == menueItemMasterDto.MenueItemId);
                if(exitsMenue==null)
                {
                    return new Tuple<int, string>(0, "Menue data not Find");
                }
                exitsMenue.ParentId = menueItemMasterDto.ParentId;
                exitsMenue.Title = menueItemMasterDto.Title;
                exitsMenue.Url = menueItemMasterDto.Url;
                exitsMenue.Description = menueItemMasterDto.Description;
                exitsMenue.CssClass = menueItemMasterDto.CssClass;
                exitsMenue.UpdatedBy = "Admin";
                exitsMenue.UpdatedOn = DateTime.UtcNow;
                _appDbContext.Update(exitsMenue);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Menue Data Update Sucessfully");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
        public async Task<Tuple<int, MenueItemMasterDto>> GetMenueById(int id)
        {
            try
            {
                var result = await _appDbContext.MenueItemMaster.AsNoTracking().Where(x => x.MenueItemId == id)
                    .Select(x => new MenueItemMasterDto
                {
                    MenueItemId = x.MenueItemId,
                    ParentId=x.ParentId,
                    Url=x.Url,
                    Title=x.Title,
                    Description=x.Description,
                    CssClass=x.CssClass,
                    CreatedBy=x.CreatedBy,
                    CreatedOn=x.CreatedOn
                }).FirstOrDefaultAsync();
                if(result == null)
                {
                    return new Tuple<int, MenueItemMasterDto>(0, null);
                }
                return new Tuple<int, MenueItemMasterDto>(1, result);
            }
            catch (Exception ex)
            {
                return new Tuple<int, MenueItemMasterDto>(-1, null);
            }
        }
        public async Task<Tuple<int,List<MenueItemMasterDto>>> getAllMenueData()
        {
            try
            {
                var menueItemData = await _appDbContext.MenueItemMaster.Select(x => new MenueItemMasterDto
                {
                    MenueItemId = x.MenueItemId,
                    ParentId = x.ParentId,
                    Url = x.Url,
                    Title = x.Title,
                    Description = x.Description,
                    CssClass = x.CssClass,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn
                }).ToListAsync();
                if(menueItemData==null)
                {
                    return new Tuple<int, List<MenueItemMasterDto>>(0, null);
                }
                return new Tuple<int, List<MenueItemMasterDto>>(1, menueItemData);
            }
            catch(Exception ex)
            {
                return new Tuple<int, List<MenueItemMasterDto>>(-1, null);
            }
        }
        public async Task<Tuple<int,string>> removeMenuById(int id)
        {
            try
            {
                var exitMenuId = await _appDbContext.MenueItemMaster.FirstOrDefaultAsync(x => x.MenueItemId == id);
                if(exitMenuId==null)
                {
                    return new Tuple<int, string>(0, "data not found");
                }
                _appDbContext.Remove(exitMenuId);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1, "Menu data removed Sucessfully");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }
    }
}

