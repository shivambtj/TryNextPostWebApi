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
        //==============================start multiple mail address's================================
//        public async Task<Tuple<int, string>> SendAsync(string emails, string userName)
//        {
//            try
//            {
//                var mailSettings = await _context.MailSettings
//                    .FirstOrDefaultAsync();

//                if (mailSettings == null)
//                    return Tuple.Create(0, "Mail settings not found.");

//                using var smtpClient = new SmtpClient(mailSettings.SmtpServer)
//                {
//                    Port = mailSettings.Port,
//                    EnableSsl = true,
//                    UseDefaultCredentials = false,
//                    Credentials = new NetworkCredential(
//                        mailSettings.FromMailAdress,
//                        mailSettings.Password)
//                };

//                var mailMessage = new MailMessage
//                {
//                    From = new MailAddress(
//                        mailSettings.FromMailAdress,
//                        "TryNextPost"),
//                    Subject = $"Registration Successful – Welcome to {userName}",
//                    IsBodyHtml = true,
//                    Body = $@"
//<html>
//<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>

//    <p>Hello <b>{userName}</b>,</p>

//    <p>Thank you for registering on <b>TryNextPost</b>.</p>

//    <p>Your account has been created successfully 🎉</p>

//    <p>
//        You can now log in and start using our services:<br><br>
//        <a href='https://trynextpost.com/login'
//           style='display:inline-block;padding:10px 15px;
//                  background:#007bff;color:#fff;
//                  text-decoration:none;border-radius:5px;'>
//           Login Here
//        </a>
//    </p>

//    <p>
//        If you did not create this account, please ignore this email.
//    </p>

//    <br/>

//    <table cellpadding='0' cellspacing='0'
//           style='font-family:Arial,sans-serif;
//                  font-size:14px;
//                  border-top:1px solid #ddd;
//                  padding-top:10px;
//                  width:100%;max-width:600px;'>

//        <tr>
//            <td style='vertical-align:top;'>
//                <b>TryNextPost</b><br/><br/>
//                📧 support@trynextpost.com<br/>
//                📞 +91-9310228489<br/>
//                🌐 https://trynextpost.com<br/>
//                📍 D-42, D Block, Sector 2,
//                Noida, Uttar Pradesh - 201301
//            </td>
//        </tr>

//    </table>

//</body>
//</html>"
//                };

//                // ============================ TO mail address's ============================
//                if (!string.IsNullOrWhiteSpace(emails))
//                {
//                    foreach (var email in emails.Split(',', StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        mailMessage.To.Add(email.Trim());
//                    }
//                }

//                // ============================CC mail address's ============================
//                if (!string.IsNullOrWhiteSpace(mailSettings.CCMailAddress))
//                {
//                    foreach (var cc in mailSettings.CCMailAddress.Split(',', StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        mailMessage.CC.Add(cc.Trim());
//                    }
//                }

//                // ============================ BCC mail address's============================
//                if (!string.IsNullOrWhiteSpace(mailSettings.BCCMailAddress))
//                {
//                    foreach (var bcc in mailSettings.BCCMailAddress.Split(',', StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        mailMessage.Bcc.Add(bcc.Trim());
//                    }
//                }

//                await smtpClient.SendMailAsync(mailMessage);

//                return Tuple.Create(1, "Mail Sent Successfully");
//            }
//            catch (Exception ex)
//            {
//                return Tuple.Create(0, ex.Message);
//            }
//        }

        //=================================end multiple mail address's==========================================
        //=================================start single mail address used ======================================
        public async Task<Tuple<int, string>> SendAsync(string email, string userName)
        {
            var mailSettings = await _context.MailSettings.FirstOrDefaultAsync(x=>x.MailFor=="Information");
            new SmtpClient(mailSettings.SmtpServer)
            {
                Port = mailSettings.Port,
                Credentials = new NetworkCredential(
                   mailSettings.FromMailAdress,
                   mailSettings.Password),
                EnableSsl = true
            }
           ;
            using var smtpClient = new SmtpClient(mailSettings.SmtpServer)
            {
                Port = mailSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
        mailSettings.FromMailAdress,
        mailSettings.Password)
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(mailSettings.FromMailAdress),
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
            //====================start if i have to send main on cc and bcc so i can used these 2 functions ===================================
            //if (!string.IsNullOrWhiteSpace(mailSettings.CCMailAddress))
            //    mailMessage.CC.Add(mailSettings.CCMailAddress);

            //if (!string.IsNullOrWhiteSpace(mailSettings.BCCMailAddress))
            //    mailMessage.Bcc.Add(mailSettings.BCCMailAddress);
            //====================end if i have to send main on cc and bcc so i can used these 2 functions ===================================

            await smtpClient.SendMailAsync(mailMessage);
            return new Tuple<int,string>(1, "Mail Sent Successfully");
        }
        //===============================end single mail address used=====================================

        //=================================start send otp to mail address created by nisha on 26/6/2026=======================
        public async Task<Tuple<int, string>> SendOTPForMail(string email, string OTP, string username)
        {
            var mailSettings = await _context.MailSettings.FirstOrDefaultAsync(x => x.MailFor == "Information");

            using var smtpClient = new SmtpClient(mailSettings.SmtpServer)
            {
                Port = mailSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailSettings.FromMailAdress, mailSettings.Password)
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(mailSettings.FromMailAdress),
                Subject = $"SendOtp  – Welcome to {username}",
                Body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
</head>
<body style='margin:0; padding:20px; background-color:#f5f5f5; font-family:Arial, Helvetica, sans-serif;'>

    <table cellpadding='0' cellspacing='0' width='100%' style='max-width:650px; margin:auto; background:#ffffff; border-radius:8px; border:1px solid #e5e5e5;'>

        <!-- Header -->
        <tr>
            <td style='background:#0d6efd; color:#ffffff; text-align:center; padding:20px; border-radius:8px 8px 0 0;'>
                <h2 style='margin:0;'>Password Reset Request</h2>
            </td>
        </tr>

        <!-- Body -->
        <tr>
            <td style='padding:30px;'>

                <p>Hello <b>{username}</b>,</p>

                <p>
                    We received a request to reset your password for your
                    <b>TryNextPost</b> account.
                </p>

                <p>Your One-Time Password (OTP) is:</p>

                <div style='text-align:center; margin:25px 0;'>
                    <span style='display:inline-block;
                                 padding:15px 35px;
                                 font-size:30px;
                                 font-weight:bold;
                                 letter-spacing:6px;
                                 color:#0d6efd;
                                 border:2px dashed #0d6efd;
                                 border-radius:8px;'>
                        {OTP}
                    </span>
                </div>

                <p>
                    This OTP is valid for <b>5 minutes</b>.
                </p>

                <p>
                    Please do not share this OTP with anyone for security reasons.
                </p>

                <p>
                    If you did not request a password reset, you can safely ignore this email.
                </p>

                <br>

                <p>
                    Regards,<br>
                </p>

            </td>
        </tr>

        <!-- Footer -->
        <tr>
            <td style='border-top:1px solid #e5e5e5; padding:20px;'>

                <table cellpadding='0' cellspacing='0' width='100%'>

                    <tr>

                        <td style='width:110px; vertical-align:top;'>

                            <img src='https://trynextpost.com/images/logo.jpeg'
                                 alt='TryNextPost'
                                 style='width:90px; height:auto;' />

                        </td>

                        <td style='vertical-align:top; font-size:14px; color:#555;'>

                            <p style='margin:0; font-size:16px; font-weight:bold;'>
                                TryNextPost
                            </p>

                            <p style='margin:8px 0 0; line-height:22px;'>
                                📧 support@trynextpost.com<br>
                                📞 +91-9310228489<br>
                                🌐 <a href='https://trynextpost.com' style='color:#0d6efd;'>https://trynextpost.com</a><br>
                                📍 D-42, D Block, Sector 2,<br>
                                Noida, Uttar Pradesh - 201301
                            </p>

                        </td>

                    </tr>

                </table>

            </td>
        </tr>

    </table>

</body>
</html>",
                IsBodyHtml = true
            };

                mailMessage.To.Add(email);
            await smtpClient.SendMailAsync(mailMessage);
            return new Tuple<int, string>(1, "Mail Sent Successfully");
        }       
        //=================================end send otp to mail address created by nisha on 26/6/2026=======================

    }
}