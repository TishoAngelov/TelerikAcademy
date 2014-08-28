using System;
using System.Net.Mail;

namespace ESchoolDiary
{
    public class MailUtil
    {
        private SmtpClient SetClientSettings()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            client.Credentials = new System.Net.NetworkCredential("eschooldiary@gmail.com", "987123654");

            return client;
        }

        public void SendMail(string receiver, string subject, string from, string body)
        {
            SmtpClient client = SetClientSettings();

            MailMessage message = new MailMessage();

            message.To.Add(receiver);
            message.Subject = subject;

            message.From = new MailAddress(from);
            message.Body = String.Format(body);
            client.Send(message);
        }
    }
}