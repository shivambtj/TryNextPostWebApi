using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenueItemMasterController : ControllerBase
    {
        private readonly IMenueItemMasterService _menueItemMasterService;
        public MenueItemMasterController(IMenueItemMasterService menueItemMasterService)
        {
            _menueItemMasterService = menueItemMasterService;
        }
        [HttpPost("SaveMenueData")]
        public async Task<IActionResult> SaveMenueData([FromBody] MenueItemMasterDto menueItemMasterDto)
        { 
            try
            {
                var result = await _menueItemMasterService.saveMenuedata(menueItemMasterDto);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                return Ok(new
                {
                    success = true,
                    message = result.Item2
                });

            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
        }
    }
}
}
