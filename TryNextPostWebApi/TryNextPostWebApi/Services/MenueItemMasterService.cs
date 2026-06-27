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
        //public async Task<int,string> GetMenueById(int id)
        //{
        //    try
        //    {
        //        var result = await _appDbContext.MenueItemMaster.FirstOrDefaultAsync(x=>x.)
        //        return new Tuple<int, string>(1, result);
        //    }
        //    catch(Exception ex)
        //    {
        //        return new Tuple<int, string>(-1, ex.Message);
        //    }
        //}
    }
}

