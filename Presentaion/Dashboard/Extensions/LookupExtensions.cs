using Microsoft.AspNetCore.Mvc.Rendering;
using TemplateFw.Dtos.Dtos.Common;

namespace TemplateFw.Dashboard.Extensions
{
    public static class LookupExtensions
    {
        public static SelectList ToSelectList(this List<LookupDto> lokupList)
        {
            return new SelectList(lokupList, nameof(LookupDto.Id), nameof(LookupDto.Text));
        }
    }
}
