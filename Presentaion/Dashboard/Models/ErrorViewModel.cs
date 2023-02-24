using TemplateFw.Resources;
using TemplateFw.Shared.Domain.Enums;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Dashboard.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorVm
    {
        public string Title { get; set; }
        public string ErrorCodes { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }

    }
  
}
