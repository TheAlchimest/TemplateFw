using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TemplateFw.Dashboard.Controllers;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Resources;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Dashboard.Extensions
{
    public static class LookupExtensions
    {
        public static SelectList ToSelectList(this List<LookupDto> lokupList)
        {
            return new SelectList(lokupList, nameof(LookupDto.Id), nameof(LookupDto.Text));
        }
    }

    public static class WebResponseExtensions
    {
        private static string ToErrorMessage(this OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            return localizer[$"OperationFailed_{(int)operation}"].Value;
        }
        private static string ToSuccessMessage(this OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            return localizer[$"OperationDone_{(int)operation}"].Value;
        }
        private static string ToErrorCodes(this OperationTypes operation)
        {
            return ((int)operation + 1000).ToString();
        }

        public static List<string> ToErrorMessages(this int[] errors, IStringLocalizer<SharedResource> localizer)
        {
            List<string> messages = new List<string>();
            errors.ToList().ForEach(e => messages.Add(localizer[$"Exception{e}"].Value));
            return messages;
        }
        public static List<string> ToErrorMessages(this List<int> errors, IStringLocalizer<SharedResource> localizer)
        {
            List<string> messages = new List<string>();
            errors.ToList().ForEach(e => messages.Add(localizer[$"Exception{e}"].Value));
            return messages;
        }

        public static void PopulateErrorResponse(this WebResponse response, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            response.ErrorCodes = operation.ToErrorCodes();
            response.Message = operation.ToErrorMessage(localizer);
            response.Title = localizer[$"Error"].Value;
            response.Icon = "fa-times-circle";
            response.Status = false;
        }
        public static void PopulateErrorResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            response.ErrorCodes = operation.ToErrorCodes();
            if (apiResult != null && apiResult.ErrorCodes != null && apiResult.ErrorCodes.Length > 0)
            {
                response.Title = operation.ToErrorMessage(localizer);
                response.Messages = apiResult.ErrorCodes.ToErrorMessages(localizer);
            }
            else
            {
                response.Title = localizer[$"Error"].Value;
                response.Message = operation.ToErrorMessage(localizer);

            }

            response.Icon = "fa-times-circle";
            response.Status = false;
        }
        public static void PopulateSuccededResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            response.ErrorCodes = null;
            response.Message = operation.ToSuccessMessage(localizer);
            response.Status = true;
        }
        public static void PopulateSuccededResponse<T>(this GenericWebResponse<T> response, GenericApiResponse<T> apiResult, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            response.ErrorCodes = null;
            response.Data = apiResult.Data;
            response.Message = operation.ToSuccessMessage(localizer);
            response.Status = true;
        }
        public static void PopulateResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            if (apiResult is null)//fail
            {
                response.PopulateErrorResponse(operation, localizer);
            }
            else if (!apiResult.Status)//fail
            {
                response.PopulateErrorResponse(apiResult, operation, localizer);
            }
            else//success
            {
                response.PopulateSuccededResponse(apiResult, operation, localizer);
            }
        }
        public static void PopulateResponse<T>(this GenericWebResponse<T> response, GenericApiResponse<T> apiResult, OperationTypes operation, IStringLocalizer<SharedResource> localizer)
        {
            if (apiResult is null)//fail
            {
                response.PopulateErrorResponse(operation, localizer);
            }
            else if (!apiResult.Status)//fail
            {
                response.PopulateErrorResponse(apiResult, operation, localizer);
            }
            else//success
            {
                response.PopulateSuccededResponse(apiResult, operation, localizer);
            }
        }

    }


    public static class ControllersExtensions
    {

        public static JsonResult ReturnJsonxResponse<T>(this LocalizedController controller, GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new GenericWebResponse<T>();
            response.PopulateResponse(apiResult, operation, controller.Localizer);
            return controller.Json(response);
        }
        public static JsonResult ReturnJsonResponse(this LocalizedController controller, ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new WebResponse();
            response.PopulateResponse(apiResult, operation, controller.Localizer);
            return controller.Json(response);
        }
    }
}
