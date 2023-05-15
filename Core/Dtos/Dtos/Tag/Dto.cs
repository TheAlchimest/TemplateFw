
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class TagDto
    {
        public int TagId { get; set; }
		public string TitleAr { get; set; }
		public string TitleEn { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class TagInfoDto
    {
        public int TagId { get; set; }
		public string Title { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class TagFilter
    {
        public string Title { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class TagDtoInsertValidator : AbstractValidator<TagDto>
    {
        public TagDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.TitleAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Tag_TitleAr"]);

			RuleFor(x => x.TitleEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Tag_TitleEn"]);


        }
    }
    
    public class TagDtoUpdateValidator : TagDtoInsertValidator
    {
        public TagDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.TagId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Tag_TagId"]);


        }
    }
    
    public class TagFilterValidator : AbstractValidator<TagFilter>
    {
        public TagFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Title)
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Tag_TitleAr"]);


        }
    }
}
