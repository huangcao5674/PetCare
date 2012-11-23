using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace PetCare.DBUtility
{
    public static class CUtilities
    {
        static CUtilities()
        {
        }
        public static void SendMail(string from, string to, string subject, string body)
        {
            //配置邮件客户端
            SmtpClient mailClient = new SmtpClient(CPetCareConfiguration.MailServer);

            //设置验证信息
            mailClient.Credentials = new NetworkCredential(from, CPetCareConfiguration.MailPassword);
            
            //创建电子邮件
            MailMessage mailMessage = new MailMessage();
           // mailMessage.ReplyTo = new MailAddress("honkcal@163.com");
          MailAddressCollection aa =  new MailAddressCollection();
            aa.Add(new MailAddress("honkcal@163.com"));
            
            mailMessage.Body = "aaa";
            mailMessage.From = new MailAddress("petcareweb@163.com");

            //发送电子邮件
            mailClient.Send(mailMessage);
        }
    }
}
