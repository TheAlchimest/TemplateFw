
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
		public int SubscriptionId { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class PaymentInfoDto
    {
        public int PaymentId { get; set; }
		public int SubscriptionId { get; set; }
		public string PaymentMethod { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class PaymentFilter
    {
        public string CreatedBy { get; set; }
		public int? SubscriptionId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class PaymentDtoInsertValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.SubscriptionId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName(modulesLocalizer["Payment_Subscription"]);

			RuleFor(x => x.Amount)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Payment_Amount"]);

			RuleFor(x => x.PaymentDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Payment_PaymentDate"]);


        }
    }
    
    public class PaymentDtoUpdateValidator : PaymentDtoInsertValidator
    {
        public PaymentDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.PaymentId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Payment_PaymentId"]);


        }
    }
    
    public class PaymentFilterValidator : AbstractValidator<PaymentFilter>
    {
        public PaymentFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {

        }
    }
}
