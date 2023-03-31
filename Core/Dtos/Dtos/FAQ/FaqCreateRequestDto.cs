
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;

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
        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationDate { get; set; }

    }

    public class FaqInfoDto
    {
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int PortalId { get; set; }
        public int? ServiceId { get; set; }
        public bool IsAvailable { get; set; }
        public string PortalName { get; set; }
        public string ServiceName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModificationDate { get; set; }
    }

    public class FaqDetailsValidator : AbstractValidator<FaqDto>
    {
        public FaqDetailsValidator(IStringLocalizer<GlobalResourceHelper> localizer)
        {
            //
            RuleFor(p => p.QuestionAr)
                .NotEmpty().WithMessage(localizer["ValidationRequired"]).WithName(localizer["Question"])
                .NotNull()
                .MaximumLength(500).WithMessage(localizer["ValidationLength"].Value.Replace("{Length}", "500")).WithName(localizer["Question"]);
            //
            RuleFor(p => p.QuestionEn)
               .NotEmpty().WithMessage(localizer["ValidationRequired"]).WithName(localizer["Question"])
               .NotNull()
               .MaximumLength(500).WithMessage(localizer["ValidationLength"].Value.Replace("{Length}", "500")).WithName(localizer["Question"]);
            //
            RuleFor(p => p.AnswerAr)
                .NotEmpty().WithMessage(localizer["ValidationRequired"]).WithName(localizer["Answer"])
                .NotNull()
                .MaximumLength(1000).WithMessage(localizer["ValidationLength"].Value.Replace("{Length}", "1000")).WithName(localizer["Answer"]);
            //
            RuleFor(p => p.AnswerEn)
               .NotEmpty().WithMessage(localizer["ValidationRequired"]).WithName(localizer["Answer"])
               .NotNull()
               .MaximumLength(1000).WithMessage(localizer["ValidationLength"].Value.Replace("{Length}", "1000")).WithName(localizer["Answer"]);
        }
    }

}
