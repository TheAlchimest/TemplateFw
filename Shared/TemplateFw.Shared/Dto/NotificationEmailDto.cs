using TemplateFw.Shared.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Shared.Dto
{
    public class NotificationEmailDto
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string MailTo { get; set; }

        public string MailCc { get; set; }

        public string MailBcc { get; set; }

    }
}
