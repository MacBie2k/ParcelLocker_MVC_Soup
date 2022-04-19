using System;
using System.Net.Mail;

namespace ParcelLocker.ExtensionMethods
{
    public static class MailClient
    {
        public static void SendMail(string parcelNumber, string subject, string body, string email)
        {
            Program program = new Program();
            //string date = DateTime.Now.ToString(@"dd\/MM h\:mm tt");

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("macbdevelop@gmail.com");
                mail.To.Add(email);
                mail.Subject = $"ParcelLocker - paczka: {parcelNumber} - {subject}";
                mail.Body = body;

                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("macbdevelop@gmail.com", "D3v3l0p3R");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
