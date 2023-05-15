
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class UsersDto
    {
        public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string ProfileInfo { get; set; }
		public DateTime LastLoginAt { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class UsersInfoDto
    {
        public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string ProfileInfo { get; set; }
		public DateTime LastLoginAt { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class UsersFilter
    {
        public string FirstName { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class UsersDtoInsertValidator : AbstractValidator<UsersDto>
    {
        public UsersDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Users_FirstName"]);

			RuleFor(x => x.LastName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Users_LastName"]);

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,250).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "250"))
			    .Matches(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Users_Email"]);

			RuleFor(x => x.Username)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(5,20).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "5").Replace("{MaxLength}", "20"))
			    .Matches(@"^[A-Za-z0-9_]{5,20}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Users_Username"]);

			RuleFor(x => x.PasswordHash)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Users_PasswordHash"]);

			RuleFor(x => x.LastLoginAt)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Users_LastLoginAt"]);


        }
    }
    
    public class UsersDtoUpdateValidator : UsersDtoInsertValidator
    {
        public UsersDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.UserId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Users_UserId"]);


        }
    }
    
    public class UsersFilterValidator : AbstractValidator<UsersFilter>
    {
        public UsersFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .Length(2,50).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "50"))
			    .Matches(@"^[A-Za-z ]{3,50}$").WithMessage(validationLocalizer["InvalidPattern"])
			    .WithName(modulesLocalizer["Users_FirstName"]);


        }
    }
}
