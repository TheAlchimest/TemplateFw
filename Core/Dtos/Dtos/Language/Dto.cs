
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class LanguageDto
    {
        public int LanguageId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsDefault { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }

    }

    public class LanguageInfoDto
    {
        public int LanguageId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsDefault { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
    }

    public class LanguageFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class LanguageDtoInsertValidator : AbstractValidator<LanguageDto>
    {
        public LanguageDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.LanguageId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Language_LanguageId");

			RuleFor(x => x.Name)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Language_Name");

			RuleFor(x => x.Code)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(2).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "2"))
			    .WithName("Language_Code");

			RuleFor(x => x.IsDefault)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Language_IsDefault");


        }
    }
    
    public class LanguageDtoUpdateValidator : LanguageDtoInsertValidator
    {
        public LanguageDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.LanguageId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Language_LanguageId");


        }
    }
    
    public class LanguageFilterValidator : AbstractValidator<LanguageFilter>
    {
        public LanguageFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(50).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "50"))
			    .WithName("Language_Name");


        }
    }
}
