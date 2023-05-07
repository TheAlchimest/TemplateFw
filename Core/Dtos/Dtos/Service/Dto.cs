
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

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
		public string PortalName { get; set; }
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
		public string Description { get; set; }
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

    
    public class ServiceDtoInsertValidator : AbstractValidator<ServiceDto>
    {
        public ServiceDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Service_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Service_NameEn");

			RuleFor(x => x.Icon)
			    .MaximumLength(30).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "30"))
			    .WithName("Service_Icon");

			RuleFor(x => x.LogInRequired)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_LogInRequired");

			RuleFor(x => x.Url)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Service_Url");

			RuleFor(x => x.MobileUrl)
			    .MaximumLength(12).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "12"))
			    .MinimumLength(10).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "10"))
			    .Matches("/^(\\+?966|0)?5\\d{8}$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^(\\+?966|0)?5\\d{8}$/"))
			    .WithName("Service_MobileUrl");

			RuleFor(x => x.ServiceTypeId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Service_ServiceType");

			RuleFor(x => x.PdfMediaId)
			    .MaximumLength(250).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "250"))
			    .WithName("Service_PdfMediaId");

			RuleFor(x => x.Video)
			    .MaximumLength(20).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "20"))
			    .WithName("Service_Video");

			RuleFor(x => x.ServiceCode)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(40).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "40"))
			    .WithName("Service_ServiceCode");

			RuleFor(x => x.ShowInCatalog)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_ShowInCatalog");

			RuleFor(x => x.ShowInFollowUp)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_ShowInFollowUp");

			RuleFor(x => x.ShowInAssets)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_ShowInAssets");

			RuleFor(x => x.IsPublished)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_IsPublished");

			RuleFor(x => x.PublishedBy)
			    .MaximumLength(30).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "30"))
			    .WithName("Service_PublishedBy");

			RuleFor(x => x.StoppedBy)
			    .MaximumLength(30).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "30"))
			    .WithName("Service_StoppedBy");

			RuleFor(x => x.ViewOrder)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_ViewOrder");

			RuleFor(x => x.ShortDescriptionAr)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .WithName("Service_ShortDescriptionAr");

			RuleFor(x => x.ShortDescriptionEn)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .WithName("Service_ShortDescriptionEn");

			RuleFor(x => x.DescriptionAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Service_DescriptionAr");

			RuleFor(x => x.DescriptionEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Service_DescriptionEn");

			RuleFor(x => x.ConditionsAr)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_ConditionsAr");

			RuleFor(x => x.ConditionsEn)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_ConditionsEn");

			RuleFor(x => x.DocumentRequiredAr)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_DocumentRequiredAr");

			RuleFor(x => x.DocumentRequiredEn)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_DocumentRequiredEn");

			RuleFor(x => x.FeesAr)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .WithName("Service_FeesAr");

			RuleFor(x => x.FeesEn)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .WithName("Service_FeesEn");

			RuleFor(x => x.NotesAr)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_NotesAr");

			RuleFor(x => x.NotesEn)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_NotesEn");

			RuleFor(x => x.StepsAr)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_StepsAr");

			RuleFor(x => x.StepsEn)
			    .MaximumLength(1000).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "1000"))
			    .WithName("Service_StepsEn");

			RuleFor(x => x.TimeRequiredAr)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches("/^(0?[1-9]|1[0-2]):[0-5][0-9](\\s?[AP][M])?$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^(0?[1-9]|1[0-2]):[0-5][0-9](\\s?[AP][M])?$/"))
			    .WithName("Service_TimeRequiredAr");

			RuleFor(x => x.TimeRequiredEn)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches("/^(0?[1-9]|1[0-2]):[0-5][0-9](\\s?[AP][M])?$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^(0?[1-9]|1[0-2]):[0-5][0-9](\\s?[AP][M])?$/"))
			    .WithName("Service_TimeRequiredEn");


        }
    }
    
    public class ServiceDtoUpdateValidator : ServiceDtoInsertValidator
    {
        public ServiceDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.ServiceId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Service_ServiceId");


        }
    }
    
    public class ServiceFilterValidator : AbstractValidator<ServiceFilter>
    {
        public ServiceFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Service_NameAr");


        }
    }
}
