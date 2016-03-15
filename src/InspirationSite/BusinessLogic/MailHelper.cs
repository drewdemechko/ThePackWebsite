﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InspirationSite.BusinessLogic
{
    public class MailHelper
    {
        MailMessage mail;
        SmtpClient smtpClient;

        public MailHelper(string toAddress, string fromAddress, string messageSubject, string messageBody)
        {
            //Set up Email
            mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toAddress);
            mail.From = new MailAddress(fromAddress,"Contact The Pvck", System.Text.Encoding.UTF8);
            mail.Subject = messageSubject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = messageBody;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential("drew.a.demechko@gmail.com","gismo0352");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
        }

        public void Send()
        {
            //Try to send email
            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
