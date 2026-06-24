using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.Dto;
using TryNextPostWebApi.IServices;

namespace TryNextPostWebApi.Notifications
{
    public class MailNotificationService : INotificationService
    {
        private readonly AppDbContext _context;

        public MailNotificationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task <Tuple<int,string>> SendAsync(string email, string userName)
        {
            var mailSettings = await _context.MailSettings.FirstOrDefaultAsync();
            //using var smtpClient = new SmtpClient("smtp.gmail.com")
            ////new SmtpClient(mailSettings.SmtpServer)
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential(
            //        "shivam.btjalphatechnology@gmail.com",
            //        "Princeraj@8122"),
            //    EnableSsl = true
            //    //Port = mailSettings.Port,
            //    //Credentials = new NetworkCredential(
            //    //    mailSettings.MailId,
            //    //    mailSettings.Password),
            //    //EnableSsl = true
            //};
            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
        "shivam.btjalphatechnology@gmail.com",
        "bopg xups bhtk yjmi")
            };
            //var mailMessage = new MailMessage
            //{

            //    From = new MailAddress(email),
            //    //From = new MailAddress(mailSettings.MailId!),
            //    //Subject = mailSettings.Subjects,
            //    Subject = "Your Registration Confirmation",
            //    //Body = mailSettings.MessageBody,
            //    Body= "Hii, Welcome to TryNextPost, " + email,
            //    IsBodyHtml = true
            //};
            var mailMessage = new MailMessage
            {
                From = new MailAddress("shivam.btjalphatechnology@gmail.com"),
                Subject = $"Registration Successful – Welcome to {userName}",
                Body = $@"
<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>

    <p>Hello <b>{userName}</b>,</p>

    <p>Thank you for registering on <b>TryNextPost</b>.</p>

    <p>Your account has been created successfully 🎉</p>

    <p>
        You can now log in and start using our services:<br><br>
        <a href='https://trynextpost.com/login' target='_blank'
           style='display:inline-block; padding:10px 15px; background-color:#007bff; color:#fff; text-decoration:none; border-radius:5px;'>
           Login here
        </a>
    </p>

    <p>
        If you did not create this account, please ignore this email or contact our support team immediately.
    </p>

    <p>We’re happy to have you with us!</p>

    <br>

    <p>Best regards,<br>

    <!-- SIGNATURE START -->
    <br>

    <table cellpadding='0' cellspacing='0' style='font-family: Arial, sans-serif; font-size: 14px; color: #333; border-top:1px solid #ddd; padding-top:10px; width:100%; max-width:600px;'>
        <tr>
            <!-- Logo -->
            <td style='width:120px; vertical-align:top; padding-right:15px;'>
                <img src='./image/logo.jpeg' alt='TryNextPost Logo' style='width:100px; height:auto;' />
            </td>

            <!-- Details -->
            <td style='vertical-align:top;'>
                <p style='margin:0; font-size:15px;'><b>TryNextPost</b></p>

                <p style='margin:5px 0 0 0;'>
                    📧 support@trynextpost.com<br>
                    📞 +91-093102 28489<br>
                    🌐 <a href='https://trynextpost.com' target='_blank'>trynextpost.com</a><br>
                    📍 D-42, D Block, Sector 2, Noida, Uttar Pradesh 201301
                </p>
            </td>
        </tr>
    </table>

    <!-- SIGNATURE END -->

</body>
</html>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            //if (!string.IsNullOrWhiteSpace(mailSettings.CCMainId))
            //    mailMessage.CC.Add(mailSettings.CCMainId);

            //if (!string.IsNullOrWhiteSpace(mailSettings.BCCMailId))
            //    mailMessage.Bcc.Add(mailSettings.BCCMailId);

            await smtpClient.SendMailAsync(mailMessage);
            return Tuple.Create(1, "Mail Sent Successfully");
        }
    }
}