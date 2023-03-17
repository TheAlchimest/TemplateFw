using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using TemplateFw.Dtos.Common;
using TemplateFw.Resources;

namespace TemplateFw.Dtos.Announces
{
    public class AnnounceGridFilter : PaginationFilter
    {
        public int? PortalId { get; set; }
    }

    public class AnnounceRequestDto
    {
        public int Id { get; set; }
        public int? PortalId { get; set; }
        public bool IsEnabled { get; set; }
        public List<AnnounceDetailRequestDto> AnnounceDetails { get; set; }
    }

    public class AnnounceDetailRequestDto
    {
        public int LanguageId { get; set; }
        public string Content { get; set; }
    }

    public class AnnounceDetailsValidator : AbstractValidator<AnnounceDetailRequestDto>
    {
        public AnnounceDetailsValidator(IStringLocalizer<SharedResource> localizer)
        {
            RuleFor(p => p.Content)
                .NotEmpty().WithMessage(localizer["ValidationRequired"]).WithName(localizer["Content"])
                .NotNull()
                .MaximumLength(2000).WithMessage(localizer["ValidationLength"].Value.Replace("{Length}", "2000"))
                .WithName(localizer["Content"]);
        }
    }
}
