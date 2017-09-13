using System;
using MailKit.Net.Smtp;
using MailReceiver.Models;
using MimeKit;
using static System.Console;

namespace MailReceiver 
{
    class MailSender
    {
        public EmailConfigModel EmailConfig { get; set; }
        public MailSender() {}

        public MailSender(EmailConfigModel emailConfig)
        {
            if (emailConfig == null)
                throw new ArgumentNullException(nameof(emailConfig));

            EmailConfig = emailConfig;
        }

        public void Send(EmailMessageModel model) 
        {
            if (EmailConfig == null)
                throw new InvalidOperationException("Invalid email configuration");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(model.SenderName, model.From));
            message.To.Add(new MailboxAddress(model.RecipientName, model.To));
            message.ReplyTo.Add(new MailboxAddress(model.ReplyTo));
            message.Subject = model.Subject;

            foreach (string email in model.Cc)
            {
                message.Cc.Add(new MailboxAddress(email));
            }

            foreach (string email in model.Bcc)
            {
                message.Bcc.Add(new MailboxAddress(email));
            }

            var builder = new BodyBuilder();
            builder.HtmlBody = model.HtmlMessage;
            builder.TextBody = model.RawMessage;

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s,c,h,e) => true;

                client.Connect(EmailConfig.ServerName, EmailConfig.Port, false);

                // Note: since we don't have an OAuth2 token, disable
				// the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(EmailConfig.UserName, EmailConfig.Passwd);

                try
                {
                    WriteLine($"Sending message to: {model.RecipientName}<{model.To}>...");
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}