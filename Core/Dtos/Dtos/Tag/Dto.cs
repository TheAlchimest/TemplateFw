
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
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Tag_TitleAr");

			RuleFor(x => x.TitleEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Tag_TitleEn");


        }
    }
    
    public class TagDtoUpdateValidator : TagDtoInsertValidator
    {
        public TagDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.TagId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Tag_TagId");


        }
    }
    
    public class TagFilterValidator : AbstractValidator<TagFilter>
    {
        public TagFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Title)
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Tag_TitleAr");


        }
    }
}
