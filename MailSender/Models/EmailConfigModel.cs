using System;
using MessagePack;

namespace MailSender.Models
{
    [MessagePackObject]
    class EmailConfigModel
    {
        [Key (0)]
        public string UserName { get; set; }
        [Key (1)]
        public string Passwd { get; set; }
        [Key (2)]
        public string ServerName { get; set; }
        [Key (3)]
        public int Port { get; set; }
    }
}