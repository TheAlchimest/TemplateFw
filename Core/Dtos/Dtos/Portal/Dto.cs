
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
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class PortalInfoDto
    {
        public int PortalId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
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
			    .WithName(modulesLocalizer["Portal_PortalId"]);

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Portal_NameAr"]);

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Portal_NameEn"]);

			RuleFor(x => x.DescriptionAr)
			    .Length(10,500).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "500"))
			    .WithName(modulesLocalizer["Portal_DescriptionAr"]);

			RuleFor(x => x.DescriptionEn)
			    .Length(10,500).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "500"))
			    .WithName(modulesLocalizer["Portal_DescriptionEn"]);

			RuleFor(x => x.Link)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,200).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "200"))
			    .Matches(@"^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Portal_Link"]);


        }
    }
    
    public class PortalDtoUpdateValidator : PortalDtoInsertValidator
    {
        public PortalDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.PortalId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Portal_PortalId"]);


        }
    }
    
    public class PortalFilterValidator : AbstractValidator<PortalFilter>
    {
        public PortalFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Portal_NameAr"]);


        }
    }
}
