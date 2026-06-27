using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryNextPostWebApi.Entities
{
    [Table("MENUE_ITEM_MASTER")]
    public class MenueItemMaster
    {
        [Key]
        public long MenueItemId { get; set; }
        public long ParentId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CssClass { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
