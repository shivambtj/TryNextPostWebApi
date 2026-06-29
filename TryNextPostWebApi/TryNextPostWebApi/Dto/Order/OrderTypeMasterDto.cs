namespace TryNextPostWebApi.Dto.Order
{
    public class OrderTypeMasterDto
    {
        public long OrderTypeId { get; set; }

        public string? OrderTypeName { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
