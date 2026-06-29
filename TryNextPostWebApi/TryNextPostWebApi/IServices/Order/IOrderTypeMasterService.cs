using TryNextPostWebApi.Dto.Order;

namespace TryNextPostWebApi.IServices.Order
{
    public interface IOrderTypeMasterService
    {
        Task<Tuple<int, string>> SaveOrderTypeMasterData(OrderTypeMasterDto orderTypeMasterDto);

        Task<Tuple<int, OrderTypeMasterDto>> GetOrderTypeMasterDataById(int OrderTypeId);

        Task<Tuple<int, string>> UpdateOrderTypeMasterData(OrderTypeMasterDto OrderMasterdto);

        Task<Tuple<int, List<OrderTypeMasterDto>>> GetAllOrderTypeMasterData();

        Task<Tuple<int, string>> RemoveOrderDataById(int OrderTypeId);
    }
}
