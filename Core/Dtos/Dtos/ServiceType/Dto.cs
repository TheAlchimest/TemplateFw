
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

namespace TemplateFw.Dtos
{
    public class ServiceTypeDto
    {
        public int ServiceTypeId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

    }

    public class ServiceTypeInfoDto
    {
		public string Name { get; set; }
        public int ServiceTypeId { get; set; }
        public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }
    }

    public class ServiceTypeFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }
}
