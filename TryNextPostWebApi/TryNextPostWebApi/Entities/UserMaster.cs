using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryNextPostWebApi.Entities
{
    [Table("USER_MASTER")]
    public class UserMaster
    {
        [Key]
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? AadharCard { get; set; }
        public string? PanCard { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessType { get; set; }
        public string? BrandName { get; set; } 
        public string? BankId { get; set; }
        public long RoleId { get; set; }
        public string? GSTNumber { get; set; }
        public string? ZipCode { get; set; }

        [Column(TypeName = "char(1)")]
        public string? UserStatus { get; set; }
        public DateTime? PasswordValidity { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// my code
        /// </summary>
        public string? ForgotPasswordOtp {  get; set; }
       

        public DateTime? OtpExpiryTime { get; set; }

        public bool IsOtpVerified { get; set; }
    }
}
