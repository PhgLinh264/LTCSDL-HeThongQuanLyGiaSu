using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EmailDL
    {
        QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        KhoaHocDL khoaHocDL = new KhoaHocDL();
        public EmailDL()
        {

        }
        public void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("trungtamgiasuKPL@gmail.com", "Trung tâm Gia Sư");
                var toAddress = new MailAddress(toEmail);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(fromAddress.Address, "eqtllnsfhvldnrkk")
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<KhoaHoc> GetKhoaHoc()
        {
            try
            {
                return db.KhoaHocs.ToList();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
