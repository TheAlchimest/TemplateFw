
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

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
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }

    }

    public class ServiceTypeInfoDto
    {
        public int ServiceTypeId { get; set; }
		public string Name { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
    }

    public class ServiceTypeFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class ServiceTypeDtoInsertValidator : AbstractValidator<ServiceTypeDto>
    {
        public ServiceTypeDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.ServiceTypeId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ServiceType_ServiceTypeId"]);

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ServiceType_NameAr"]);

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ServiceType_NameEn"]);


        }
    }
    
    public class ServiceTypeDtoUpdateValidator : ServiceTypeDtoInsertValidator
    {
        public ServiceTypeDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.ServiceTypeId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ServiceType_ServiceTypeId"]);


        }
    }
    
    public class ServiceTypeFilterValidator : AbstractValidator<ServiceTypeFilter>
    {
        public ServiceTypeFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ServiceType_NameAr"]);


        }
    }
}
