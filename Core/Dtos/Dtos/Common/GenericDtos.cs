﻿using System;

namespace TemplateFw.Dtos.Common
{
    
    public class PaginationFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
    public class FaqFilter 
    {
        public int? PortalId { get; set; }
        public int? ServiceId { get; set; }
        public int LanguageId { get; set; } = 1;
        public string Question { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public object ConvertToParametersExcept(Func<object, object> value1, Func<object, object> value2)
        {
            throw new NotImplementedException();
        }
    }
    public class FaqSimleFilter : PaginationFilter
    {
        public int? PortalId { get; set; }
        public int? ServiceId { get; set; }
    }

}
