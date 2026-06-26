namespace TryNextPostWebApi.Dto
{
    public class RoleMasterDto
    {
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
