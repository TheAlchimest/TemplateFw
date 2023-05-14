
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }
		public string Content { get; set; }
		public int ArticleId { get; set; }
		public int UserId { get; set; }
		public int LanguageId { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class CommentInfoDto
    {
        public int CommentId { get; set; }
		public string Content { get; set; }
		public int ArticleId { get; set; }
		public string ArticleTitle { get; set; }
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public int LanguageId { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class CommentFilter
    {
        public string Content { get; set; }
		public int? ArticleId { get; set; }
		public int? UserId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class CommentDtoInsertValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Content)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Comment_Content");

			RuleFor(x => x.ArticleId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Comment_Article");

			RuleFor(x => x.UserId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName("Comment_User");

			RuleFor(x => x.LanguageId)
			    .NotNull().WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Comment_LanguageId");


        }
    }
    
    public class CommentDtoUpdateValidator : CommentDtoInsertValidator
    {
        public CommentDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.CommentId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Comment_CommentId");


        }
    }
    
    public class CommentFilterValidator : AbstractValidator<CommentFilter>
    {
        public CommentFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Content)
			    .MaximumLength(500).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "500"))
			    .WithName("Comment_Content");


        }
    }
}
