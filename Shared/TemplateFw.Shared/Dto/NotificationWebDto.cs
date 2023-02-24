using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Shared.Dto
{
    public class NotificationWebDto
    {
        public string ServiceName { get; set; }
        public List<NotificationWebDetailDto> Details  { get; set; }
        public string Link { get; set; }
    }
}
