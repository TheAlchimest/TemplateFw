﻿using Microsoft.Extensions.Localization;
using TemplateFw.Resources;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;

namespace TemplateFw.Dashboard.Extensions
{
    public static class WebResponseExtensions
    {
        public static void PopulateErrorResponse(this WebResponse response, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            response.ErrorCodes = operation.ToErrorCodes();
            response.Message = operation.ToErrorMessage(localizer);
            response.Title = localizer[$"OperationErrorTitle"].Value;
            response.Icon = "fa-times-circle";
            response.Status = false;
        }

        public static void PopulateErrorResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            response.ErrorCodes = operation.ToErrorCodes();
            if (apiResult?.ErrorCodes?.Length > 0)
            {
                response.Title = operation.ToErrorMessage(localizer);
                response.Messages = apiResult.ErrorCodes.ToErrorMessages(localizer);
            }
            else
            {
                response.Title = localizer[$"OperationErrorTitle"].Value;
                response.Message = operation.ToErrorMessage(localizer);
            }

            response.Icon = "fa-times-circle";
            response.Status = false;
        }

        public static void PopulateSuccededResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            response.ErrorCodes = null;
            response.Message = operation.ToSuccessMessage(localizer);
            response.Status = true;
        }

        public static void PopulateSuccededResponse<T>(this GenericWebResponse<T> response, GenericApiResponse<T> apiResult, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            response.ErrorCodes = null;
            response.Data = apiResult.Data;
            response.Message = operation.ToSuccessMessage(localizer);
            response.Status = true;
        }

        public static void PopulateResponse(this WebResponse response, ApiResponse apiResult, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            if (apiResult is null)
            {
                response.PopulateErrorResponse(operation, localizer);
            }
            else if (!apiResult.Status)
            {
                response.PopulateErrorResponse(apiResult, operation, localizer);
            }
            else
            {
                response.PopulateSuccededResponse(apiResult, operation, localizer);
            }
        }

        public static void PopulateResponse<T>(this GenericWebResponse<T> response, GenericApiResponse<T> apiResult, OperationTypes operation, IStringLocalizer<OperationsResource2> localizer)
        {
            if (apiResult is null)
            {
                response.PopulateErrorResponse(operation, localizer);
            }
            else if (!apiResult.Status)
            {
                response.PopulateErrorResponse(apiResult, operation, localizer);
            }
            else
            {
                response.PopulateSuccededResponse(apiResult, operation, localizer);
            }
        }

       

        public static List<string> ToErrorMessages(this IEnumerable<int> errors, IStringLocalizer<OperationsResource2> localizer)
        {
            return errors.Select(e => localizer[$"Exception{e}"].Value).ToList();
        }
    }
}
