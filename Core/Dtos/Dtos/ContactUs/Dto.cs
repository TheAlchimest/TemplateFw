
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class ContactUsDto
    {
        public int MessageId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Message { get; set; }
		public int LanguageId { get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class ContactUsInfoDto
    {
        public int MessageId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Message { get; set; }
		public int LanguageId { get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class ContactUsFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class ContactUsDtoInsertValidator : AbstractValidator<ContactUsDto>
    {
        public ContactUsDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("ContactUs_Name");

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .MinimumLength(5).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "5"))
			    .WithName("ContactUs_Email");

			RuleFor(x => x.Phone)
			    .MaximumLength(20).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "20"))
			    .MinimumLength(8).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "8"))
			    .WithName("ContactUs_Phone");

			RuleFor(x => x.Message)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(16).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "16"))
			    .WithName("ContactUs_Message");

			RuleFor(x => x.LanguageId)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("ContactUs_LanguageId");


        }
    }
    
    public class ContactUsDtoUpdateValidator : ContactUsDtoInsertValidator
    {
        public ContactUsDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.MessageId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("ContactUs_MessageId");


        }
    }
    
    public class ContactUsFilterValidator : AbstractValidator<ContactUsFilter>
    {
        public ContactUsFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("ContactUs_Name");


        }
    }
}
