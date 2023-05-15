
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
		public string YoutubeChannelURL { get; set; }
		public DateTime BirthDate { get; set; }
		public string BirthHijriDate { get; set; }
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
		public string YoutubeChannelURL { get; set; }
		public DateTime BirthDate { get; set; }
		public string BirthHijriDate { get; set; }
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
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_FirstName"]);

			RuleFor(x => x.LastName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_LastName"]);

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "100"))
			    .Matches(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_Email"]);

			RuleFor(x => x.Phone)
			    .Length(8,20).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "8").Replace("{MaxLength}", "20"))
			    .Matches(@"^\d+$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_Phone"]);

			RuleFor(x => x.Mobile)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,12).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "12"))
			    .Matches(@"^(\+?966|0)?5\d{8}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_Mobile"]);

			RuleFor(x => x.Biography)
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName(modulesLocalizer["Author_Biography"]);

			RuleFor(x => x.ProfileUrl)
			    .MaximumLength(150).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "150"))
			    .WithName(modulesLocalizer["Author_ProfileUrl"]);

			RuleFor(x => x.IDNumber)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Author_IDNumber"]);

			RuleFor(x => x.CountryId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName(modulesLocalizer["Author_Country"]);

			RuleFor(x => x.PostalCode)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Author_PostalCode"]);

			RuleFor(x => x.Address)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "150"))
			    .WithName(modulesLocalizer["Author_Address"]);

			RuleFor(x => x.Website)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "150"))
			    .Matches(@"^https://[^\s/$.?#].[^\s]*$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_Website"]);

			RuleFor(x => x.ProfileLink)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "150"))
			    .Matches(@"^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_ProfileLink"]);

			RuleFor(x => x.YoutubeChannelURL)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,150).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "150"))
			    .Matches(@"^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_YoutubeChannelURL"]);

			RuleFor(x => x.BirthDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Author_BirthDate"]);

			RuleFor(x => x.BirthHijriDate)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,10).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "10"))
			    .Matches(@"^1[3-4]\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[0])$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_BirthHijriDate"]);


        }
    }
    
    public class AuthorDtoUpdateValidator : AuthorDtoInsertValidator
    {
        public AuthorDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.AuthorId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Author_AuthorId"]);


        }
    }
    
    public class AuthorFilterValidator : AbstractValidator<AuthorFilter>
    {
        public AuthorFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Author_FirstName"]);


        }
    }
}
