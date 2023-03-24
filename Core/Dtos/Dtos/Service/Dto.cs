
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

namespace TemplateFw.Dtos
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string Icon { get; set; }
		public bool LogInRequired { get; set; }
		public string Url { get; set; }
		public string MobileUrl { get; set; }
		public int ServiceTypeId { get; set; }
		public string PdfMediaId { get; set; }
		public string Video { get; set; }
		public int? PortalId { get; set; }
		public string ServiceCode { get; set; }
		public bool ShowInCatalog { get; set; }
		public bool ShowInFollowUp { get; set; }
		public bool ShowInAssets { get; set; }
		public bool IsPublished { get; set; }
		public string PublishedBy { get; set; }
		public DateTime? PublishedAt { get; set; }
		public string StoppedBy { get; set; }
		public DateTime? StoppedAt { get; set; }
		public int ViewOrder { get; set; }
		public string ShortDescriptionAr { get; set; }
		public string ShortDescriptionEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public string ConditionsAr { get; set; }
		public string ConditionsEn { get; set; }
		public string DocumentRequiredAr { get; set; }
		public string DocumentRequiredEn { get; set; }
		public string FeesAr { get; set; }
		public string FeesEn { get; set; }
		public string NotesAr { get; set; }
		public string NotesEn { get; set; }
		public string StepsAr { get; set; }
		public string StepsEn { get; set; }
		public string TimeRequiredAr { get; set; }
		public string TimeRequiredEn { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

    }

    public class ServiceInfoDto
    {
        public int ServiceId { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
        public bool LogInRequired { get; set; }
		public string Url { get; set; }
		public string MobileUrl { get; set; }
		public int ServiceTypeId { get; set; }
		public string ServiceTypeName { get; set; }
		public string PdfMediaId { get; set; }
		public string Video { get; set; }
		public int? PortalId { get; set; }
		public string ServiceCode { get; set; }
		public bool ShowInCatalog { get; set; }
		public bool ShowInFollowUp { get; set; }
		public bool ShowInAssets { get; set; }
		public bool IsPublished { get; set; }
		public string PublishedBy { get; set; }
		public DateTime? PublishedAt { get; set; }
		public string StoppedBy { get; set; }
		public DateTime? StoppedAt { get; set; }
		public int ViewOrder { get; set; }
		public string ShortDescription { get; set; }
		public string Conditions { get; set; }
		public string DocumentRequired { get; set; }
		public string Fees { get; set; }
		public string Notes { get; set; }
		public string Steps { get; set; }
		public string TimeRequired { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }
    }

    public class ServiceFilter
    {
        public string Name { get; set; }
		public int? ServiceTypeId { get; set; }
		public int? PortalId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }
}
