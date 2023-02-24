using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Shared.Dto
{
    public class NotificationSmsDto
    {
        public string Body { get; set; }

        public string Mobile { get; set; }

        public string Tag { get; set; }

        public string Notes { get; set; }
    }
}
