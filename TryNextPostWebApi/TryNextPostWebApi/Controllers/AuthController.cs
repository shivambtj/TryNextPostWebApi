using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser([FromBody]UserMasterDto userMasterDto)
        {
            try
            {
                var result = await _authService.Login(userMasterDto);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 3)
                {
                    return BadRequest(new
                    {
                        sucess = false,
                        Message = result.Item2
                    });
                }
                else if (result.Item1 == 4)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 5)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 6)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 7)
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
                    Status = result.Item1,
                    Message = result.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser([FromBody] UserMasterDto userMasterDto)
        {
            try
            {
                var result = await _authService.Logout(userMasterDto);

                if (result.Item1 < 0 || result.Item1 == 0 || result.Item1 == 1)
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
                    status = result.Item1,
                    message = result.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserMasterDto userMasterDto)

        {
            try
            {
                var result = await _authService.UserRegister(userMasterDto);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if(result.Item1==3)
                {
                    return BadRequest(new
                    {
                        sucess=false,
                        Message= result.Item2
                    });
                }
                else if (result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        sucess = false,
                        Message = result.Item2
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

        [HttpPost("forgetPassword")]
        public async Task<IActionResult> ForgetPassword(string emailId)
        {
            try
            {
                var result = await _authService.ForgetPasswordAsync(emailId);

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
        [HttpPost("verifyPassword")]
        public async Task<IActionResult> verifyPassword(string otp)
        {
            try
            {
                var result = await _authService.verifyPassword(otp);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 2)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 3)
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

        [HttpPost("newPassword")]
        public async Task<IActionResult> newPassword(UserMasterDto userMasterDto)
        {
           try
            {
                var result = await _authService.NewPassword(userMasterDto);
                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if (result.Item1 == 1)
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



    }
}
