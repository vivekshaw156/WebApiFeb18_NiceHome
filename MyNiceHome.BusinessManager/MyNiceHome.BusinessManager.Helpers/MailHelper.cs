using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MyNiceHome.Manager.Helpers
{
    /// <summary>
    /// Helper Method for Mailing
    /// </summary>
    class MailHelper
    {
        MailAddress mailFrom;
        SmtpClient smtp;

        /// <summary>
        /// MailHelper Method
        /// </summary>
        public MailHelper()
        {
            mailFrom = new MailAddress("mynicehome.application@gmail.com");
            smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("mynicehome.application@gmail.com", "mynicehome9"),
                EnableSsl = true
            };
        }

        /// <summary>
        /// SendTo method for MailIng to Someone
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
       public bool sendTo(string mailTo, string subject, string body)
        {

            try
            {
                MailMessage mail = new MailMessage("mynicehome.application@gmail.com", mailTo)
                {
                    Body = body,
                    Subject = subject
                };
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
