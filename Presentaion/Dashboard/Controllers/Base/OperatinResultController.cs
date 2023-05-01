using Dashboard.Common.WebClientHelpers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System.Globalization;
using TemplateFw.Dashboard.Extensions;
using TemplateFw.Dtos;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Dashboard.Controllers
{
    public class OperatinResultController : Controller
    {
        private IStringLocalizer<OperationsResource> _localizer;
        public IStringLocalizer<OperationsResource> Localizer
            => _localizer ??= HttpContext.RequestServices.GetService<IStringLocalizer<OperationsResource>>();
        public string CurrentCulture
           => HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name;

        public OperatinResultController()
        {
            var ci = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }


        public JsonResult ReturnJsonResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateResponse(apiResult, operation);
            return Json(response);
        }
        public JsonResult ReturnJsonResponse(ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateResponse(apiResult, operation);
            return Json(response);
        }
        #region  UnhandledErrorForJsonResult
        public JsonResult ReturnJsonException(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateErrorResponse(null, operation);
            return Json(response);
        }
        #endregion





        #region  ApiErrorForViewResult
      
       
        public ViewResult ReturnViewResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown, string viewName=null )
        {
            if ((apiResult is null) || (!apiResult.Status))
            {
                return ReturnViewException((ApiResponse?)null, operation);
            }
            else
            {
                return (viewName!=null)?View(viewName, apiResult.Data): View(apiResult.Data);
            }
        }
        #region  UnhandledErrorForViewResult
        public ViewResult ReturnViewException(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            return ReturnViewException((ApiResponse?)null, operation);
        }
        #endregion
        public ViewResult ReturnViewException(ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateErrorResponse(apiResult, operation);
            return View("/Views/Error/Error-Generic.cshtml", response);

        }
        #endregion

        public JsonResult ReturnInvalidModel(ModelStateDictionary modelState)
        {
            WebResponse response = new WebResponse();

            foreach (var item in modelState.Values)
            {
                foreach (ModelError error in item.Errors)
                {
                    response.Messages.Add(error.ErrorMessage);
                }
            }
            response.Title = Localizer["Error"];
            response.Status = false;
            return Json(response);
        }

        public IActionResult ReturnInvalidModel(ValidationResult validationResult)
        {
            WebResponse response = new WebResponse();
            response.Message= Localizer["Error"];
            foreach (var item in validationResult.Errors)
            {
                response.Errors.Add(new ValidationError
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName,
                    ErrorCode = item.ErrorCode
                });
            }
            response.Title = Localizer["Error"];
            response.Status = false;
            return Json(response);
        }


        public  WebResponse PopulateErrorResponse(OperationTypes operation)
        {
            var response = new WebResponse();
            response.ErrorCodes = operation.ToErrorCodes();
            response.Message = operation.ToErrorMessage(Localizer);
            response.Title = Localizer[$"OperationErrorTitle"].Value;
            response.Icon = "fa-times-circle";
            response.Status = false;
            return response;
        }

        public  WebResponse PopulateErrorResponse(ApiResponse apiResult, OperationTypes operation)
        {
            var response = new WebResponse();
            response.ErrorCodes = operation.ToErrorCodes();
            if (apiResult?.ErrorCodes?.Length > 0)
            {
                response.Title = operation.ToErrorMessage(Localizer);
                response.Messages = apiResult.ErrorCodes.ToErrorMessages(Localizer);
            }
            else
            {
                response.Title = Localizer[$"OperationErrorTitle"].Value;
                response.Message = operation.ToErrorMessage(Localizer);
            }

            response.Icon = "fa-times-circle";
            response.Status = false;
            return response;
        }

        public  WebResponse PopulateSuccededResponse(ApiResponse apiResult, OperationTypes operation)
        {
            var response = new WebResponse();
            response.ErrorCodes = null;
            response.Message = operation.ToSuccessMessage(Localizer);
            response.Status = true;
            return response;
        }

        public  WebResponse PopulateSuccededResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation)
        {
            var response = new GenericWebResponse<T>();
            response.ErrorCodes = null;
            response.Data = apiResult.Data;
            response.Message = operation.ToSuccessMessage(Localizer);
            response.Status = true;
            return response;
        }

        public  WebResponse PopulateResponse(ApiResponse apiResult, OperationTypes operation)
        {

            if (apiResult is null)
            {
                return PopulateErrorResponse(operation);
            }
            else if (!apiResult.Status)
            {
                return PopulateErrorResponse(apiResult, operation);
            }
            else
            {
                return PopulateSuccededResponse(apiResult, operation);
            }
        }

        public  WebResponse PopulateResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation)
        {
            if (apiResult is null)
            {
                return PopulateErrorResponse(operation);
            }
            else if (!apiResult.Status)
            {
                return PopulateErrorResponse(apiResult, operation);
            }
            else
            {
                return PopulateSuccededResponse(apiResult, operation);
            }
        }

    }
}

