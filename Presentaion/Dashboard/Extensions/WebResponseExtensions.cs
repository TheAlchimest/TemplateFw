using Microsoft.Extensions.Localization;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Dashboard.Extensions
{
    public static class WebResponseExtensions
    {
        internal static string ToErrorMessage(this OperationTypes operation, IStringLocalizer<OperationsResource> localizer)
        {
            return localizer[$"OperationFailed_{(int)operation}"].Value;
        }

        internal static string ToSuccessMessage(this OperationTypes operation, IStringLocalizer<OperationsResource> localizer)
        {
            return localizer[$"OperationDone_{(int)operation}"].Value;
        }

        internal static string ToErrorCodes(this OperationTypes operation)
        {
            return ((int)operation + 1000).ToString();
        }

        public static List<string> ToErrorMessages(this IEnumerable<int> errors, IStringLocalizer<OperationsResource> localizer)
        {
            return errors.Select(e => localizer[$"Exception{e}"].Value).ToList();
        }
    }
}
