
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
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ContactUs_Name"]);

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ContactUs_Email"]);

			RuleFor(x => x.Phone)
			    .Length(8,20).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "8").Replace("{MaxLength}", "20"))
			    .Matches(@"^\d+$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ContactUs_Phone"]);

			RuleFor(x => x.Message)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,16).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "16"))
			    .WithName(modulesLocalizer["ContactUs_Message"]);

			RuleFor(x => x.LanguageId)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ContactUs_LanguageId"]);


        }
    }
    
    public class ContactUsDtoUpdateValidator : ContactUsDtoInsertValidator
    {
        public ContactUsDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.MessageId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["ContactUs_MessageId"]);


        }
    }
    
    public class ContactUsFilterValidator : AbstractValidator<ContactUsFilter>
    {
        public ContactUsFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .Length(5,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "50"))
			    .Matches(@"^(?:[A-Za-z\u0600-\u06FF][A-Za-z0-9\u0600-\u06FF.,'""\- ]{3,149})$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["ContactUs_Name"]);


        }
    }
}
