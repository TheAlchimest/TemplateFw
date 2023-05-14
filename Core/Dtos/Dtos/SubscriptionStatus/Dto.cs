
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class SubscriptionStatusDto
    {
        public int SubscriptionStatusId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class SubscriptionStatusInfoDto
    {
        public int SubscriptionStatusId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class SubscriptionStatusFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class SubscriptionStatusDtoInsertValidator : AbstractValidator<SubscriptionStatusDto>
    {
        public SubscriptionStatusDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionStatusId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("SubscriptionStatus_SubscriptionStatusId");

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("SubscriptionStatus_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("SubscriptionStatus_NameEn");

			RuleFor(x => x.DescriptionAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(200).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "200"))
			    .WithName("SubscriptionStatus_DescriptionAr");

			RuleFor(x => x.DescriptionEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(200).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "200"))
			    .WithName("SubscriptionStatus_DescriptionEn");


        }
    }
    
    public class SubscriptionStatusDtoUpdateValidator : SubscriptionStatusDtoInsertValidator
    {
        public SubscriptionStatusDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionStatusId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("SubscriptionStatus_SubscriptionStatusId");


        }
    }
    
    public class SubscriptionStatusFilterValidator : AbstractValidator<SubscriptionStatusFilter>
    {
        public SubscriptionStatusFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("SubscriptionStatus_NameAr");


        }
    }
}
