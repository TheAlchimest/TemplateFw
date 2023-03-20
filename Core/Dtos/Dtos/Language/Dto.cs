
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

namespace TemplateFw.Dtos
{
    public class LanguageDto
    {
        public int LanguageId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsDefault { get; set; }
		public bool IsAvailable { get; set; }

    }

    public class LanguageInfoDto
    {
        public int LanguageId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsDefault { get; set; }
		public bool IsAvailable { get; set; }
    }

    public class LanguageFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }
}
