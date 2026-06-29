using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryNextPostWebApi.Entities.Order
{
    [Table("ORDER_TYPE_MASTER")]
    public class OrderTypeMaster
    {
        [Key]
        public long OrderTypeId { get; set; }

        public string? OrderTypeName { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
