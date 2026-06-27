using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryNextPostWebApi.Entities
{
    [Table("MAIL_SETTINGS")]
    public class MailSettings
    {
        [Key]
        public long MailSettingsId { get; set; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? FromMailAdress { get; set; }
        public string? Password { get; set; }
        public string? ToMailAddress { get; set; }
        public string? CCMailAddress { get; set; }
        public string? BCCMailAddress { get; set; }
        public string? Subjects { get; set; }
        public string? MessageBody { get; set; }
        public string? MailFor { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
