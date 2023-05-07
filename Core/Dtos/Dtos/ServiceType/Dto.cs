
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
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

    }

    public class ServiceTypeInfoDto
    {
        public int ServiceTypeId { get; set; }
		public string Name { get; set; }
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

    
    public class ServiceTypeDtoInsertValidator : AbstractValidator<ServiceTypeDto>
    {
        public ServiceTypeDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.ServiceTypeId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("ServiceType_ServiceTypeId");

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"/^[A-Za-z]{5,120}$/").WithMessage(validationLocalizer["Pattern"])
			    .WithName("ServiceType_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"/^[A-Za-z]{5,120}$/").WithMessage(validationLocalizer["Pattern"])
			    .WithName("ServiceType_NameEn");


        }
    }
    
    public class ServiceTypeDtoUpdateValidator : ServiceTypeDtoInsertValidator
    {
        public ServiceTypeDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.ServiceTypeId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("ServiceType_ServiceTypeId");


        }
    }
    
    public class ServiceTypeFilterValidator : AbstractValidator<ServiceTypeFilter>
    {
        public ServiceTypeFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"/^[A-Za-z]{5,120}$/").WithMessage(validationLocalizer["Pattern"])
			    .WithName("ServiceType_NameAr");


        }
    }
}
