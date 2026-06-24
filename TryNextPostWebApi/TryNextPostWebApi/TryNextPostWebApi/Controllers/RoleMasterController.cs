using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController : ControllerBase
    {
        private readonly IRoleMasterService _roleMasterService;
        public RoleMasterController(IRoleMasterService roleMasterService)
        {
            _roleMasterService = roleMasterService;
        }
        [HttpPost("SaveRoleData")]
        public async Task<IActionResult> SaveRoleData([FromBody] RoleMasterDto roleMasterDto)
        {

            try
            {
                var result = await _roleMasterService.SaveRoleData(roleMasterDto);
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
                    Message = result.Item2
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateRoleData")]
        public async Task<IActionResult> EditRoleData([FromBody] RoleMasterDto roleMasterDto)
        {
            try
            {
                var result = await _roleMasterService.UpdateRoleData(roleMasterDto);
                if(result.Item1 == 0)
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
                    Message = result.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    }
        [HttpGet("GetRoleDataById/{roleId}")]
        public async Task<IActionResult> GetRoleDataById(int roleId)
        {
            try
            {
                var result = await _roleMasterService.GetRoleDataById(roleId);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "user data not found"
                    });
                }
                return Ok(new
                {
                    success = true,
                    Message = result.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllData")]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                var result = await _roleMasterService.getAllData();
                if (result.Item1 == 0 || result.Item1==-1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "user data not found"
                    });
                }

                return Ok(new
                {
                    success = true,
                    Message = result.Item2
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
}
