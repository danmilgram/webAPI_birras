using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Services
{
    public class EmailService
    {
        public static string emailConfigurationSmtpServer { set; get; }
        public static int emailConfigurationSmtpPort { set; get; }
        public static string emailConfigurationSmtpUsername{get;set; }
        public static string emailConfigurationSmtpPassword { get; set; }

        public static void SendMail(string para, string asunto, string texto)
        {
            MimeMessage msg = createMail(para, asunto, texto);
            Send(msg);
        }

        private static MimeMessage createMail(string para, string asunto, string texto)
        {
            var messageToSend = new MimeMessage
            {                
                Subject = asunto
            };

            messageToSend.From.Add(MailboxAddress.Parse(emailConfigurationSmtpUsername));
            messageToSend.Body = new TextPart(TextFormat.Html) { Text = texto };
            messageToSend.To.Add(MailboxAddress.Parse(para.ToString()));
            messageToSend.Cc.Add(MailboxAddress.Parse("ddmilgram@gmail.com"));

            return messageToSend;
        }


        private static void Send(MimeMessage message)
        {
            try
            {
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect(emailConfigurationSmtpServer, emailConfigurationSmtpPort, false);
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(emailConfigurationSmtpUsername, emailConfigurationSmtpPassword);
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
