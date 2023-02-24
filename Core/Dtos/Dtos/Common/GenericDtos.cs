using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Dtos.Common
{
    public class GridFilter : PaginationParameter
    {
        public int? PortalId { get; set; }
        public int? ServiceId { get; set; }
    }
    public class PaginationParameter
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string Search { get; set; }
        public int LanguageId { get; set; } = 1;
    }
    public class FaqGridFilter : PaginationParameter
    {
        public int? PortalId { get; set; }
        public int? ServiceId { get; set; }
    }
    public class FaqSimleFilter : PaginationParameter
    {
        public int? PortalId { get; set; }
        public int? ServiceId { get; set; }
    }

}
