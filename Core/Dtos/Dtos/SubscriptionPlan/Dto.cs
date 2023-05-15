
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class SubscriptionPlanDto
    {
        public int SubscriptionPlanId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public decimal Price { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class SubscriptionPlanInfoDto
    {
        public int SubscriptionPlanId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class SubscriptionPlanFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class SubscriptionPlanDtoInsertValidator : AbstractValidator<SubscriptionPlanDto>
    {
        public SubscriptionPlanDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionPlanId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["SubscriptionPlan_SubscriptionPlanId"]);

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["SubscriptionPlan_NameAr"]);

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["SubscriptionPlan_NameEn"]);

			RuleFor(x => x.DescriptionAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,200).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "200"))
			    .WithName(modulesLocalizer["SubscriptionPlan_DescriptionAr"]);

			RuleFor(x => x.DescriptionEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,200).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "200"))
			    .WithName(modulesLocalizer["SubscriptionPlan_DescriptionEn"]);

			RuleFor(x => x.Price)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["SubscriptionPlan_Price"]);


        }
    }
    
    public class SubscriptionPlanDtoUpdateValidator : SubscriptionPlanDtoInsertValidator
    {
        public SubscriptionPlanDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionPlanId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["SubscriptionPlan_SubscriptionPlanId"]);


        }
    }
    
    public class SubscriptionPlanFilterValidator : AbstractValidator<SubscriptionPlanFilter>
    {
        public SubscriptionPlanFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["SubscriptionPlan_NameAr"]);


        }
    }
}
