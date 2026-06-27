using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryNextPostWebApi.Entities
{
    [Table("ROLE_MASTER")]
    public class RoleMaster
    {
        [Key]
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
