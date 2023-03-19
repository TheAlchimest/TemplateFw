using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System.Globalization;
using TemplateFw.Dashboard.Extensions;
using TemplateFw.Dtos;
using TemplateFw.Resources;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Dashboard.Controllers
{
    public class LocalizedController : Controller
    {
        private IStringLocalizer<OperationsResource> _localizer;
        public IStringLocalizer<OperationsResource> Localizer
            => _localizer ??= HttpContext.RequestServices.GetService<IStringLocalizer<OperationsResource>>();
        public string CurrentCulture
           => HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name;

        public LocalizedController()
        {
            var ci = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }


        public JsonResult ReturnJsonResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new GenericWebResponse<T>();
            response.PopulateResponse(apiResult, operation, Localizer);
            return Json(response);
        }
        public JsonResult ReturnJsonResponse(ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            var response = new WebResponse();
            response.PopulateResponse(apiResult, operation, Localizer);
            return Json(response);
        }
        #region  UnhandledErrorForJsonResult
        public JsonResult ReturnJsonResponse(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            return ReturnJsonResponse((ApiResponse?)null, operation);
        }
        #endregion





        #region  ApiErrorForViewResult
        public async Task<IActionResult> ReturnViewResponse<T>(RequestUrlHelper _api, string apiUrl, object dto, OperationTypes operation = OperationTypes.Unknown)
        {
            try
            {
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<FaqInfoDto>>>(apiUrl, dto);
                return ReturnViewResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }
        }
        public ViewResult ReturnViewResponse<T>(GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            if ((apiResult is null) || (!apiResult.Status))
            {
                return ReturnViewErrorResponseForApiResponse(apiResult, operation);
            }
            else
            {
                return View(apiResult.Data);
            }
        }
        public ViewResult ReturnViewResponse<T>(string viewName, GenericApiResponse<T> apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            if ((apiResult is null) || (!apiResult.Status))
            {
                return ReturnViewErrorResponseForApiResponse((ApiResponse?)null, operation);
            }
            else
            {
                return View(viewName, apiResult.Data);
            }
        }
        #region  UnhandledErrorForViewResult
        public ViewResult ReturnViewResponse(Exception ex, OperationTypes operation = OperationTypes.Unknown)
        {
            return ReturnViewErrorResponseForApiResponse((ApiResponse?)null, operation);
        }
        #endregion
        public ViewResult ReturnViewErrorResponseForApiResponse(ApiResponse apiResult, OperationTypes operation = OperationTypes.Unknown)
        {
            WebResponse response = new WebResponse();
            response.PopulateResponse(apiResult, operation, Localizer);
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



    }
}

