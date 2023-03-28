using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Shared.Helpers;
using Microsoft.Extensions.Localization;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;
using Azure;
using static Dashboard.Common.WebClientHelpers.InternalApiDictionary;

namespace TemplateFw.Dashboard.Controllers
{
    [AllowAnonymous]
    public class LookupController : WebBaseController<FaqController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;

        [HttpGet]

        public async Task<JsonResult> Countries()
        {
            string url = CountryUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	[HttpGet]

        public async Task<JsonResult> Faqs(int? portalId = null, int? serviceId = null)
        {
            string url = string.Format(FaqUrls.GetLookup, portalId, serviceId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	[HttpGet]

        public async Task<JsonResult> Languages()
        {
            string url = LanguageUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	[HttpGet]

        public async Task<JsonResult> Portals()
        {
            string url = PortalUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	[HttpGet]

        public async Task<JsonResult> Services(int? serviceTypeId = null, int? portalId = null)
        {
            string url = string.Format(ServiceUrls.GetLookup, serviceTypeId, portalId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	[HttpGet]

        public async Task<JsonResult> ServiceTypes()
        {
            string url = ServiceTypeUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }

    }
}
