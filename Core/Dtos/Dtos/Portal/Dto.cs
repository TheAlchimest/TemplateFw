
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

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

    
    public class PortalDtoInsertValidator : AbstractValidator<PortalDto>
    {
        public PortalDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.PortalId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Portal_PortalId");

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .Matches("/^[A-Za-z]{5,50}$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^[A-Za-z]{5,50}$/"))
			    .WithName("Portal_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .Matches("/^[A-Za-z]{5,50}$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^[A-Za-z]{5,50}$/"))
			    .WithName("Portal_NameEn");

			RuleFor(x => x.DescriptionAr)
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Portal_DescriptionAr");

			RuleFor(x => x.DescriptionEn)
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Portal_DescriptionEn");

			RuleFor(x => x.Link)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(200).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "200"))
			    .MinimumLength(2).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "2"))
			    .Matches("/^(https?:\\/\\/)?([a-zA-Z0-9-]+\\.)?[a-zA-Z0-9-]+\\.[a-zA-Z]{2,20}(\\/.*)?$/i").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^(https?:\\/\\/)?([a-zA-Z0-9-]+\\.)?[a-zA-Z0-9-]+\\.[a-zA-Z]{2,20}(\\/.*)?$/i"))
			    .WithName("Portal_Link");


        }
    }
    
    public class PortalDtoUpdateValidator : PortalDtoInsertValidator
    {
        public PortalDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.PortalId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Portal_PortalId");


        }
    }
    
    public class PortalFilterValidator : AbstractValidator<PortalFilter>
    {
        public PortalFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .Matches("/^[A-Za-z]{5,50}$/").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", " /^[A-Za-z]{5,50}$/"))
			    .WithName("Portal_NameAr");


        }
    }
}
