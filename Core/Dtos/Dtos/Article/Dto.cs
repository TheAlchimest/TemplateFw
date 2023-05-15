
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }
		public string TitleAr { get; set; }
		public string TitleEn { get; set; }
		public string BriefAr { get; set; }
		public string BriefEn { get; set; }
		public string ContentAr { get; set; }
		public string ContentEn { get; set; }
		public int AuthorId { get; set; }
		public int? CategoryId { get; set; }
		public DateTime PublishingDate { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class ArticleInfoDto
    {
        public int ArticleId { get; set; }
		public string Title { get; set; }
		public string Brief { get; set; }
		public string Content { get; set; }
		public int AuthorId { get; set; }
		public string FirstName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public DateTime PublishingDate { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class ArticleFilter
    {
        public string Title { get; set; }
		public int? AuthorId { get; set; }
		public int? CategoryId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class ArticleDtoInsertValidator : AbstractValidator<ArticleDto>
    {
        public ArticleDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.TitleAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Article_TitleAr"]);

			RuleFor(x => x.TitleEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Article_TitleEn"]);

			RuleFor(x => x.BriefAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,250).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "250"))
			    .WithName(modulesLocalizer["Article_BriefAr"]);

			RuleFor(x => x.BriefEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .Length(10,250).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "10").Replace("{MaxLength}", "250"))
			    .WithName(modulesLocalizer["Article_BriefEn"]);

			RuleFor(x => x.ContentAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Article_ContentAr"]);

			RuleFor(x => x.ContentEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Article_ContentEn"]);

			RuleFor(x => x.AuthorId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName(modulesLocalizer["Article_Author"]);

			RuleFor(x => x.PublishingDate)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Article_PublishingDate"]);


        }
    }
    
    public class ArticleDtoUpdateValidator : ArticleDtoInsertValidator
    {
        public ArticleDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.ArticleId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Article_ArticleId"]);


        }
    }
    
    public class ArticleFilterValidator : AbstractValidator<ArticleFilter>
    {
        public ArticleFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Title)
			    .Length(2,100).WithMessage(validationLocalizer["RangeLengthCharacters"].Value.Replace("{MinLength}", "2").Replace("{MaxLength}", "100"))
			    .WithName(modulesLocalizer["Article_TitleAr"]);


        }
    }
}
