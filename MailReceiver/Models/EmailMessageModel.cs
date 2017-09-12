using System;
using System.Collections.Generic;
using MessagePack;

namespace MailReceiver.Models
{
    [MessagePackObject]
    class EmailMessageModel
    {
        [Key(0)]
        public string SenderName { get; set; }
        [Key(1)]
        public string From { get; set; }
        [Key(2)]
        public string ReplyTo { get; set; }
        [Key(3)]
        public string To { get; set; }
        [Key(4)]
        public HashSet<string> Cc { get; set; } = new HashSet<string>();
        [Key(5)]
        public HashSet<string> Bcc { get; set; } = new HashSet<string>();
        [Key(6)]
        public string RawMessage { get; set; }
        [Key(7)]
        public string HtmlMessage { get; set; }
        [Key(8)]
        public string Subject { get; set; }
        [Key(9)]
        public EmailConfigModel EmailConfig { get; set; }
    }
}