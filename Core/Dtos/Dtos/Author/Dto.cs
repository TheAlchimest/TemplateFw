
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Biography { get; set; }
		public string ProfileUrl { get; set; }
		public long IDNumber { get; set; }
		public int CountryId { get; set; }
		public int PostalCode { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string ProfileLink { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class AuthorInfoDto
    {
        public int AuthorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Biography { get; set; }
		public string ProfileUrl { get; set; }
		public long IDNumber { get; set; }
		public int CountryId { get; set; }
		public string CountryName { get; set; }
		public int PostalCode { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string ProfileLink { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class AuthorFilter
    {
        public string FirstName { get; set; }
		public int? CountryId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class AuthorDtoInsertValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Author_FirstName");

			RuleFor(x => x.LastName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Author_LastName");

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .MinimumLength(5).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "5"))
			    .WithName("Author_Email");

			RuleFor(x => x.Phone)
			    .MaximumLength(20).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "20"))
			    .MinimumLength(8).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "8"))
			    .WithName("Author_Phone");

			RuleFor(x => x.Mobile)
			    .MaximumLength(12).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "12"))
			    .MinimumLength(10).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "10"))
			    .WithName("Author_Mobile");

			RuleFor(x => x.Biography)
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Author_Biography");

			RuleFor(x => x.ProfileUrl)
			    .MaximumLength(200).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "200"))
			    .WithName("Author_ProfileUrl");

			RuleFor(x => x.IDNumber)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Author_IDNumber");

			RuleFor(x => x.CountryId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Author_Country");

			RuleFor(x => x.PostalCode)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Author_PostalCode");

			RuleFor(x => x.Address)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(150).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "150"))
			    .WithName("Author_Address");

			RuleFor(x => x.Website)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(150).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "150"))
			    .MinimumLength(2).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "2"))
			    .WithName("Author_Website");

			RuleFor(x => x.ProfileLink)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(150).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "150"))
			    .MinimumLength(2).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "2"))
			    .WithName("Author_ProfileLink");


        }
    }
    
    public class AuthorDtoUpdateValidator : AuthorDtoInsertValidator
    {
        public AuthorDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.AuthorId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Author_AuthorId");


        }
    }
    
    public class AuthorFilterValidator : AbstractValidator<AuthorFilter>
    {
        public AuthorFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Author_FirstName");


        }
    }
}
