namespace TryNextPostWebApi.Dto
{
    public class MailSettingsDto
    {
        public long MailSettingsId { get; set; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? MailId { get; set; }
        public string? Password { get; set; }
        public string? ToMailId { get; set; }
        public string? CCMainId { get; set; }
        public string? BCCMailId { get; set; }
        public string? Subjects { get; set; }
        public string? MessageBody { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedOn { get; set; }
    }
}
