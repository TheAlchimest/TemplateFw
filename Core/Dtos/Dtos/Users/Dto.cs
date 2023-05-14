
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
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Users_FirstName");

			RuleFor(x => x.LastName)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Users_LastName");

			RuleFor(x => x.Email)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(255).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "255"))
			    .MinimumLength(5).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "5"))
			    .WithName("Users_Email");

			RuleFor(x => x.Username)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(20).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "20"))
			    .MinimumLength(5).WithMessage(validationLocalizer["MinLengthCharacters"].Value.Replace("{Length}", "5"))
			    .WithName("Users_Username");

			RuleFor(x => x.PasswordHash)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Users_PasswordHash");

			RuleFor(x => x.LastLoginAt)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Users_LastLoginAt");


        }
    }
    
    public class UsersDtoUpdateValidator : UsersDtoInsertValidator
    {
        public UsersDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.UserId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Users_UserId");


        }
    }
    
    public class UsersFilterValidator : AbstractValidator<UsersFilter>
    {
        public UsersFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.FirstName)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Users_FirstName");


        }
    }
}
