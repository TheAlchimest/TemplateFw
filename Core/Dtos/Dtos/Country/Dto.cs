
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class CountryDto
    {
        public int CountryId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string Code { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }

    }

    public class CountryInfoDto
    {
        public int CountryId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreationDate { get; set; }
		public string LastModifiedBy { get; set; }
		public DateTime? LastModificationDate { get; set; }
    }

    public class CountryFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class CountryDtoInsertValidator : AbstractValidator<CountryDto>
    {
        public CountryDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.CountryId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Country_CountryId");

			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    //.Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Country_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    //.Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Country_NameEn");

			RuleFor(x => x.Code)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(2).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "2"))
			    .WithName("Country_Code");


        }
    }
    
    public class CountryDtoUpdateValidator : CountryDtoInsertValidator
    {
        public CountryDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.CountryId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Country_CountryId");


        }
    }
    
    public class CountryFilterValidator : AbstractValidator<CountryFilter>
    {
        public CountryFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(120).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "120"))
			    .Matches(@"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$").WithMessage(validationLocalizer["Pattern"].Value.Replace("{Value}", @"^[a-zA-Z0-9\s\u0080-\uFFFF]{1,150}$"))
			    .WithName("Country_NameAr");


        }
    }
}
