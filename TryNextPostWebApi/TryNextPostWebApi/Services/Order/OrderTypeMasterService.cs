using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto.Order;
using TryNextPostWebApi.Entities.Order;
using TryNextPostWebApi.IServices.Order;

namespace TryNextPostWebApi.Services.Order
{
    public class OrderTypeMasterService : IOrderTypeMasterService
    {
        private readonly AppDbContext _appDbContext;
        public OrderTypeMasterService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
         public async Task<Tuple<int,string>> SaveOrderTypeMasterData(OrderTypeMasterDto orderTypeMasterDto)
        {
            try
            {
                var exitsOrderTypeMaster =await _appDbContext.OrderTypeMasters.AnyAsync( x => x.OrderTypeName == orderTypeMasterDto.OrderTypeName);
                if(exitsOrderTypeMaster)
                {
                    return new Tuple<int, string>(0,"Order Type Already Exits");
                }
                _appDbContext.OrderTypeMasters.Add(new Entities.Order.OrderTypeMaster
                {
                    OrderTypeName = orderTypeMasterDto.OrderTypeName,
                    CreatedBy = "admin",
                    CreatedOn = DateTime.UtcNow
                });
                await _appDbContext.SaveChangesAsync();

                return new Tuple<int, string>(1, "Order Type Data Saved Successfully. ");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, $"Error saving Order Type data: {ex.Message}");
            }
        }

        //===========================start get Order Type data access by id=======================
        public async Task<Tuple<int, OrderTypeMasterDto>> GetOrderTypeMasterDataById(int OrderTypeId)
        {
            try
            {
                var OrderTypeData = await _appDbContext.OrderTypeMasters.AsNoTracking().Where(x => x.OrderTypeId == OrderTypeId).Select(x => new OrderTypeMasterDto
                {
                    OrderTypeId = x.OrderTypeId,
                    OrderTypeName = x.OrderTypeName,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).FirstOrDefaultAsync();

                if(OrderTypeData == null)
                {
                    return new Tuple<int, OrderTypeMasterDto>(0, null);
                }
                return new Tuple<int, OrderTypeMasterDto>(1, OrderTypeData);
            }
            catch(Exception ex)
            {
                return new Tuple<int, OrderTypeMasterDto>(-1, null);
            }
        }

        public async Task<Tuple<int,string>> UpdateOrderTypeMasterData(OrderTypeMasterDto OrderMasterdto)
        {
            try
            {
                var OrderMasterData = await _appDbContext.OrderTypeMasters.FirstOrDefaultAsync(x => x.OrderTypeId == OrderMasterdto.OrderTypeId);
                if(OrderMasterData == null)
                {
                    return new Tuple<int, string>(0, "Order Type Not Exist.");
                }
                else
                {
                    OrderMasterData.OrderTypeName = OrderMasterdto.OrderTypeName ?? "";
                    OrderMasterData.UpdatedBy = "admin1";
                    OrderMasterData.UpdatedOn = DateTime.UtcNow;
                    _appDbContext.Update(OrderMasterData);
                    await _appDbContext.SaveChangesAsync();

                    return new Tuple<int, string>(1, "Order Type Data Updated Successfully");

                }            
                    
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, $"Error saving Order Type data: {ex.Message}");
            }
        }

        public async Task<Tuple<int, List<OrderTypeMasterDto>>> GetAllOrderTypeMasterData()
        {
            try
            {
                var AllOrderData = await _appDbContext.OrderTypeMasters.Select(x => new OrderTypeMasterDto
                {
                    OrderTypeId = x.OrderTypeId,
                    OrderTypeName = x.OrderTypeName,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).ToListAsync();

                if(AllOrderData == null)
                {
                    return new Tuple<int, List<OrderTypeMasterDto>>(0, null);
                }

                return new Tuple<int, List<OrderTypeMasterDto>>(1, AllOrderData);
            }
            catch(Exception ex)
            {
                return new Tuple<int, List<OrderTypeMasterDto>>(-1, null);
            }
        }

        public async Task<Tuple<int,string>> RemoveOrderDataById(int OrderTypeId)
        {
            try
            {
                var OrderId = await _appDbContext.OrderTypeMasters.FirstOrDefaultAsync(x => x.OrderTypeId == OrderTypeId);
                if(OrderId == null)
                {
                    return new Tuple<int, string>(0, "Data Not Found");
                }
                _appDbContext.Remove(OrderId);
                await _appDbContext.SaveChangesAsync();
                return new Tuple<int, string>(1,"Order Type Data Removed Sucessfully");
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, ex.Message);
            }
        }

    }
}
