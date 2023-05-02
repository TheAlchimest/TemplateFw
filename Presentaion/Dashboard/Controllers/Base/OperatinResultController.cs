﻿using Dashboard.Common.WebClientHelpers;
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
        private IStringLocalizer<OperationsResource> localizer;
        public IStringLocalizer<OperationsResource> Localizer {
            get {
                if (localizer == null)
                {
                    localizer = HttpContext.RequestServices.GetService<IStringLocalizer<OperationsResource>>();
                }
                return localizer;
            }
        }

        #region ReturnJsonResponse
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
        public JsonResult ReturnJsonException(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateErrorResponse(null, operation);
            return Json(response);
        }
        #endregion

        #region  ReturnViewResponse


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
        public ViewResult ReturnViewException(ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = PopulateErrorResponse(apiResult, operation);
            return View("/Views/Error/Error-Generic.cshtml", response);

        }
        //UnhandledErrorForViewResult
        public ViewResult ReturnViewException(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            return ReturnViewException((ApiResponse?)null, operation);
        }
        #endregion

        #region handle BadRequest

        public ActionResult ReturnBadRequest(ModelStateDictionary modelState)
        {
            var response = new CommonWebResponse
            {
                Title = Localizer["Error"],
                Status = false,
                Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(error => new CommonError
                    {
                        PropertyName = key,
                        ErrorMessage = error.ErrorMessage
                    }))
                    .ToList()
            };

            return BadRequest(response);
        }
        public ActionResult ReturnBadRequest(ValidationResult validationResult)
        {
            var response = new CommonWebResponse
            {
                Title = Localizer["Error"],
                Status = false,
                Errors = validationResult.Errors.Select(e => new CommonError
                {
                    ErrorMessage = e.ErrorMessage,
                    PropertyName = e.PropertyName,
                    ErrorCode = e.ErrorCode
                }).ToList()
            };

            return BadRequest(response);
        }
        #endregion

        #region PopulateWebResponse

        protected CommonWebResponse PopulateResponse(ApiResponse apiResult, OperationTypes operation)
        {

            if (apiResult is null || !apiResult.Status)
            {
                return PopulateErrorResponse(apiResult, operation);
            }
            else
            {
                return PopulateSuccededResponse(apiResult, operation);
            }
        }

        protected GenericWebResponse<T> PopulateResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation)
        {
            if (apiResult is null || !apiResult.Status)
            {
                var webResponse = PopulateErrorResponse(apiResult, operation);
                return new GenericWebResponse<T>(webResponse);
            }
            else
            {
                return PopulateSuccededResponse(apiResult, operation);
            }
        }
        protected CommonWebResponse PopulateSuccededResponse(ApiResponse apiResult, OperationTypes operation)
        {
            var response = new CommonWebResponse
            {
                Message = operation.ToSuccessMessage(Localizer),
                Status = true,
            };
            return response;
        }
        protected GenericWebResponse<T> PopulateSuccededResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation)
        {
            var response = new GenericWebResponse<T>
            {
                Data = apiResult.Data,
                Message = operation.ToSuccessMessage(Localizer),
                Status = true
            };
            return response;
        }

        protected CommonWebResponse PopulateErrorResponse(OperationTypes operation)
        {
            var response = new CommonWebResponse
            {
                Title = Localizer[$"OperationErrorTitle"].Value,
                Icon = "fa-times-circle",
                Status = false
            };
            response.Errors.Add(new CommonError
            {
                ErrorMessage = operation.ToErrorMessage(Localizer),
                ErrorCode = operation.ToErrorCodes()
            });
            return response;
        }

        protected CommonWebResponse PopulateErrorResponse(ApiResponse apiResult, OperationTypes operation)
        {
            var response = new CommonWebResponse
            {
                Title = Localizer[$"OperationErrorTitle"].Value,
                Icon = "fa-times-circle",
                Status = false
            };
            if (apiResult?.Errors?.Count > 0)
            {
                response.Message = operation.ToErrorMessage(Localizer);
                response.Errors = apiResult.Errors.Where(e=>!string.IsNullOrEmpty(e.ErrorMessage)).ToList();
                response.StatusCode = apiResult.StatusCode;
            }
            else
            {
                response.Errors.Add(new CommonError
                {
                    ErrorMessage = operation.ToErrorMessage(Localizer),
                    ErrorCode = operation.ToErrorCodes()
                }); 
            }
            return response;
        }
        #endregion

    }
}

