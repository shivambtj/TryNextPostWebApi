using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MailSettingsController : ControllerBase
    {
        private readonly IMailSettingsService _mailSettingsService;
        public MailSettingsController(IMailSettingsService mailSettingsService)
        {
            _mailSettingsService = mailSettingsService;
        }
        [HttpPost("SaveMailData")]
        public async Task<IActionResult> SaveMAilData([FromBody] MailSettingsDto mailSettingsDto)
        {

            try
            {
                var result = await _mailSettingsService.SaveMailData(mailSettingsDto);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateMailData")]
        public async Task<IActionResult> UpdateMailData([FromBody] MailSettingsDto mailSettingsDto)
        {
            try
            {
                var result = await _mailSettingsService.UpdateMailData(mailSettingsDto);

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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetMailById/{MailSettingsId}")]
        public async Task<IActionResult> GetMailById(int MailSettingsId)
        {
            try
            {
                var result = await _mailSettingsService.GetDataById(MailSettingsId);


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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllData")]
        public async Task<IActionResult> getAllData()
        {
            try
            {
                var result = await _mailSettingsService.getAllData();
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
        [HttpDelete("RemoveMailSettingById/{id}")]
        public async Task<IActionResult> RemoveMailSettingById(long id)
        {
            try
            {
                var result = await _mailSettingsService.removeDataById(id);

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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
