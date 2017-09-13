using System;
using System.Collections.Generic;
using MessagePack;

namespace MailSender.Models
{
    [MessagePackObject]
    class EmailMessageModel
    {
        [Key (0)]
        public string SenderName { get; set; }
        [Key (1)]
        public string From { get; set; }
        [Key (2)]
        public string ReplyTo { get; set; }
        [Key (3)]
        public string RecipientName { get; set; }
        [Key (4)]
        public string To { get; set; }
        [Key (5)]
        public HashSet<string> Cc { get; set; } = new HashSet<string> ();
        [Key (6)]
        public HashSet<string> Bcc { get; set; } = new HashSet<string> ();
        [Key (7)]
        public string RawMessage { get; set; }
        [Key (8)]
        public string HtmlMessage { get; set; }
        [Key (9)]
        public string Subject { get; set; }
        [Key (10)]
        public EmailConfigModel EmailConfig { get; set; }
    }
}