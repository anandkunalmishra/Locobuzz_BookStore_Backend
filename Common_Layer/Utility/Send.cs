using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Common_Layer.Utility
{
	public class Send
	{
        public string SendMail(string ToEmail, string Token)
        {
            string FromEmail = "am9233@srmist.edu.in";
            //string resetPasswordLink = $"http://localhost:4200/resetPass/{Token}";

            using (MailMessage message = new MailMessage(FromEmail, ToEmail))
            {
                message.Subject = "Link For Resetting Password";
                //message.Body = $"<a href=\"{resetPasswordLink}\">Click here to reset your password</a>";
                message.Body = $"The token for reset password is : {Token}";
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    NetworkCredential credential = new NetworkCredential(FromEmail, "kgfb nypp nsbk sznv");
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;

                    smtp.Send(message);
                }
            }

            return ToEmail;
        }
    }
}

