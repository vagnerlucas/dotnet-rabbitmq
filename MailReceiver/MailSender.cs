using System;
using MailReceiver.Models;

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

            
        }
    }
}