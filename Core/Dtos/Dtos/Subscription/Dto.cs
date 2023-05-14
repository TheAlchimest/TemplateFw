
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class SubscriptionDto
    {
        public int SubscriptionId { get; set; }
		public int UserId { get; set; }
		public int SubscriptionPlanId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int? SubscriptionStatusId { get; set; }
		public string PaymentMethod { get; set; }
		public decimal Amount { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class SubscriptionInfoDto
    {
        public int SubscriptionId { get; set; }
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public int SubscriptionPlanId { get; set; }
		public string SubscriptionPlanName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int? SubscriptionStatusId { get; set; }
		public string SubscriptionStatusName { get; set; }
		public string PaymentMethod { get; set; }
		public decimal Amount { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class SubscriptionFilter
    {
        public string PaymentMethod { get; set; }
		public int? UserId { get; set; }
		public int? SubscriptionPlanId { get; set; }
		public int? SubscriptionStatusId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class SubscriptionDtoInsertValidator : AbstractValidator<SubscriptionDto>
    {
        public SubscriptionDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.UserId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Subscription_User");

			RuleFor(x => x.SubscriptionPlanId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Subscription_SubscriptionPlan");

			RuleFor(x => x.StartDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Subscription_StartDate");

			RuleFor(x => x.EndDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Subscription_EndDate");

			RuleFor(x => x.PaymentMethod)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Subscription_PaymentMethod");

			RuleFor(x => x.Amount)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Subscription_Amount");


        }
    }
    
    public class SubscriptionDtoUpdateValidator : SubscriptionDtoInsertValidator
    {
        public SubscriptionDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Subscription_SubscriptionId");


        }
    }
    
    public class SubscriptionFilterValidator : AbstractValidator<SubscriptionFilter>
    {
        public SubscriptionFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.PaymentMethod)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Subscription_PaymentMethod");


        }
    }
}
