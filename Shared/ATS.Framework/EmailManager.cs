﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Configuration;

namespace ATS.Framework
{
    public class EmailManager
    {
        public int SendMail(string fromEmail, string toEmail, string subject, string body, string email)
        {
            try
            {
                WebMail.SmtpServer = WebConfigurationManager.AppSettings["SMTPServer"].ToString();
                WebMail.From = fromEmail;
                WebMail.Send(
                        toEmail,
                        subject,
                        body,
                        email
                    );

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
