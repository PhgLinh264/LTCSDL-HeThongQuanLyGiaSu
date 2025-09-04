using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BusinessLayer
{
    public class EmailBL
    {
        EmailDL emailDL;

        public EmailBL()
        {
            emailDL = new EmailDL();
        }
        public bool GuiEmailNhieuNguoi(List<string> dsEmail, string subject, string body)
        {
            try
            {
                if (string.IsNullOrEmpty(subject) ||
                    string.IsNullOrEmpty(body))
                    return false;

                foreach (var email in dsEmail)
                {
                    emailDL.SendEmail(email, subject, body);
                }
                return true;
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
                return emailDL.GetKhoaHoc();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
