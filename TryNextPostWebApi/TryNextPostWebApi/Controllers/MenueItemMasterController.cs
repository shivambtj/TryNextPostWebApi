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
        [HttpPut("updateMenueData")]
        public async Task<IActionResult> updateMenueData([FromBody] MenueItemMasterDto menueItemMasterDto)
        {
            try
            {
                var result = await _menueItemMasterService.updateMenueData(menueItemMasterDto);
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetMenueById")]
        public async Task<IActionResult> GetMenueById(int id)
        {
            try
            {
                var result = await _menueItemMasterService.GetMenueById(id);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                else if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                return Ok(new
                {
                    success = true,
                    message = result
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllMenueData")]
        public async Task<IActionResult> getAllMenueData()
        {
            try
            {
                var result = await _menueItemMasterService.getAllMenueData();
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                else if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                return Ok(new
                {
                    success = true,
                    message = result
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("removeMenuById")]
        public async Task<IActionResult> removeMenuById(int id)
        {
            try
            {
                var result = await _menueItemMasterService.removeMenuById(id);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                else if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result
                    });
                }
                return Ok(new
                {
                    success = true,
                    message = result
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
