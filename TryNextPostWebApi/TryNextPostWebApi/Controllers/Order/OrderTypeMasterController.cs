using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryNextPostWebApi.Dto.Order;
using TryNextPostWebApi.IServices.Order;

namespace TryNextPostWebApi.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypeMasterController : ControllerBase
    {
        private readonly IOrderTypeMasterService _orderTypeMasterService;

        public OrderTypeMasterController(IOrderTypeMasterService orderTypeMasterService)
        {
            _orderTypeMasterService = orderTypeMasterService;
        }

        [HttpPost("SaveOrderTypeMasterData")]
        public async Task<IActionResult> SaveOrderTypeMasterData(OrderTypeMasterDto orderTypeMasterDto)
        {
            try
            {
                var result = await _orderTypeMasterService.SaveOrderTypeMasterData(orderTypeMasterDto);

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
                    Success = true,
                    message = result.Item2
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetOrderTypeMasterDataById/{OrderTypeId}")]
        public async Task<IActionResult> GetOrderTypeMasterDataById(int OrderTypeId)
        {
            try
            {
                var result = await _orderTypeMasterService.GetOrderTypeMasterDataById(OrderTypeId);

                if (result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }

                return Ok(new
                {
                    Success = true,
                    message = result.Item2
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateOrderTypeMasterData")]
        public async Task<IActionResult> UpdateOrderTypeMasterData([FromBody] OrderTypeMasterDto OrderTypeDto)
        {
            try
            {
                var result = await _orderTypeMasterService.UpdateOrderTypeMasterData(OrderTypeDto);
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
                    Success = true,
                    message = result.Item2
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAllOrderTypeMasterData")]
        public async Task<IActionResult> GetAllOrderTypeMasterData()
        {
            try
            {
                var result = await _orderTypeMasterService.GetAllOrderTypeMasterData();

                if(result.Item1 == 0 || result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "User Data Not Found"
                    });
                }

                return Ok(new
                {
                    Success = true,
                    message = result
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveOrderDataById/{OrderTypeId}")]
        public async Task<IActionResult> RemoveOrderDataById(int OrderTypeId)
        {
            try
            {
                var result = await _orderTypeMasterService.RemoveOrderDataById(OrderTypeId);

                if(result.Item1 == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }
                else if(result.Item1 == -1)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = result.Item2
                    });
                }

                return Ok(new
                {
                  Success = true,
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
