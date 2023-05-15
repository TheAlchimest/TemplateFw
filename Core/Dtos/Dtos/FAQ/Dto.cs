
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class FaqDto
    {
        public int FaqId { get; set; }
		public string QuestionAr { get; set; }
		public string QuestionEn { get; set; }
		public string AnswerAr { get; set; }
		public string AnswerEn { get; set; }
		public int PortalId { get; set; }
		public int? ServiceId { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }

    }

    public class FaqInfoDto
    {
        public int FaqId { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public int PortalId { get; set; }
		public string PortalName { get; set; }
		public int? ServiceId { get; set; }
		public string ServiceName { get; set; }
		public bool IsAvailable { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreationDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
    }

    public class FaqFilter
    {
        public string Question { get; set; }
		public int? PortalId { get; set; }
		public int? ServiceId { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class FaqDtoInsertValidator : AbstractValidator<FaqDto>
    {
        public FaqDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.QuestionAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(256).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "256"))
			    .WithName(modulesLocalizer["Faq_QuestionAr"]);

			RuleFor(x => x.QuestionEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(256).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "256"))
			    .WithName(modulesLocalizer["Faq_QuestionEn"]);

			RuleFor(x => x.AnswerAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(256).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "256"))
			    .WithName(modulesLocalizer["Faq_AnswerAr"]);

			RuleFor(x => x.AnswerEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(256).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "256"))
			    .WithName(modulesLocalizer["Faq_AnswerEn"]);

			RuleFor(x => x.PortalId)
			    .NotNull().WithMessage(validationLocalizer["RequiredChoose"])
			    .WithName(modulesLocalizer["Faq_Portal"]);


        }
    }
    
    public class FaqDtoUpdateValidator : FaqDtoInsertValidator
    {
        public FaqDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.FaqId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName(modulesLocalizer["Faq_FaqId"]);


        }
    }
    
    public class FaqFilterValidator : AbstractValidator<FaqFilter>
    {
        public FaqFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Question)
			    .MaximumLength(256).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "256"))
			    .WithName(modulesLocalizer["Faq_QuestionAr"]);


        }
    }
}
