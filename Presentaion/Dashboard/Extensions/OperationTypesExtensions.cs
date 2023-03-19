using Microsoft.Extensions.Localization;
using TemplateFw.Resources;
using TemplateFw.Shared.Domain.Enums;

namespace TemplateFw.Dashboard.Extensions
{
    public static class OperationTypesExtensions
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

    }
}
