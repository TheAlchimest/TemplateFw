
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

namespace TemplateFw.Dtos
{
    public class PortalDto
    {
        public int PortalId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public string Link { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

    }

    public class PortalInfoDto
    {
        public int PortalId { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }
    }

    public class PortalFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }
}
