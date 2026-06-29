namespace TryNextPostWebApi.Dto
{
    public class UserPermissionMasterDto
    {
        public long UserPermissionId { get; set; }
        public long RoleId { get; set; }
        public long MenuId { get; set; }
        public char Add { get; set; }
        public char Edit { get; set; }
        public char Delete { get; set; }
        public char View { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
