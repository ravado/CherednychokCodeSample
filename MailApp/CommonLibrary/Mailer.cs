using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using CommonLibrary.DataModels;

namespace CommonLibrary
{
    /// <summary>
    /// Static class for sending mail 
    /// </summary>
    /// <author>Evgeny Drapoguz</author>
    /// <date>15 April 2013</date>
    public static class Mailer
    {
        #region Methods

        /// <summary>
        /// Check for Internet connection
        /// </summary>
        /// <returns>Internet status</returns>
        public static bool InternetStatus()
        {
            bool result = false;

            Ping p = new Ping();

            PingReply pr = p.Send("yandex.ru");

            IPStatus ips = pr.Status;

            if (Convert.ToString(ips) == "Success")
                result = true;

            return result;
        }

        /// <summary>
        /// Load SMTP configuration and initialization SmtpClient
        /// </summary>
        /// <returns>SmtpClient</returns>
        private static SmtpClient SmtpClientInit()
        {
            SmtpClient smptClient = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["mailerHost"],
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["mailerPort"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailerEmail"], ConfigurationManager.AppSettings["mailerPassword"])
            };

            return smptClient;
        }

        /// <summary>
        /// Send mail to the recipient
        /// </summary>
        /// <param name="mail">Mail Data Model</param>
        public static void SendMail(MailDataModel mail)
        {
            SmtpClient smtpClient = Mailer.SmtpClientInit();

            if (Mailer.InternetStatus() && smtpClient != null && mail != null)
            {
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["mailerEmail"]);

                MailAddress toAddress = new MailAddress(mail.EmailAddress);

                using (MailMessage msg = new MailMessage(fromAddress, toAddress))
                {
                    msg.Subject = mail.Subject;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;

                    msg.Body = mail.Body;
                    msg.BodyEncoding = System.Text.Encoding.UTF8;

                    smtpClient.Send(msg);
                }
            }
        }

        /// <summary>
        /// Sending emails recipient group
        /// </summary>
        /// <param name="mailQueue">Queue Mail Data Model</param>
        public static void SendMail(Queue<MailDataModel> mailQueue)
        {
            SmtpClient smtpClient = Mailer.SmtpClientInit();

            if (Mailer.InternetStatus() && smtpClient != null && mailQueue != null)
            {
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["mailerEmail"]);

                for (int i = 0; i < mailQueue.Count; i++)
                {
                    MailDataModel mail = mailQueue.Dequeue();

                    MailAddress toAddress = new MailAddress(mail.EmailAddress);

                    using (MailMessage msg = new MailMessage(fromAddress, toAddress))
                    {
                        msg.Subject = mail.Subject;
                        msg.SubjectEncoding = System.Text.Encoding.UTF8;

                        msg.Body = mail.Body;
                        msg.BodyEncoding = System.Text.Encoding.UTF8;

                        smtpClient.Send(msg);
                    }
                }
            }
        }

        public static void SendMail(IEnumerable<string> emails, string themeOfLetter, string textOfLetter)
        {
            SmtpClient smtpClient = Mailer.SmtpClientInit();

            if (Mailer.InternetStatus() && smtpClient != null && emails != null)
            {
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["mailerEmail"]);

                foreach (string email in emails)
                {
                    MailAddress toAddress = new MailAddress(email);
                    using (MailMessage msg = new MailMessage(fromAddress, toAddress))
                    {
                        msg.Subject = themeOfLetter;
                        msg.SubjectEncoding = System.Text.Encoding.UTF8;

                        msg.Body = textOfLetter;
                        msg.BodyEncoding = System.Text.Encoding.UTF8;

                        smtpClient.Send(msg);
                    }
                }
            }
        }
        #endregion
    }
}
