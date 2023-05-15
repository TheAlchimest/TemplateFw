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
        public async Task<JsonResult> Articles(int? authorId = null, int? categoryId = null)
        {
            string url = string.Format(ArticleUrls.GetLookup, authorId, categoryId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> Authors(int? countryId = null)
        {
            string url = string.Format(AuthorUrls.GetLookup, countryId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> Categories()
        {
            string url = CategoryUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> Comments(int? articleId = null, int? userId = null)
        {
            string url = string.Format(CommentUrls.GetLookup, articleId, userId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> ContactUs()
        {
            string url = ContactUsUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
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
        public async Task<JsonResult> Payments(int? subscriptionId = null)
        {
            string url = string.Format(PaymentUrls.GetLookup, subscriptionId);
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
	
        [HttpGet]
        public async Task<JsonResult> Subscriptions(int? userId = null, int? subscriptionPlanId = null, int? subscriptionStatusId = null)
        {
            string url = string.Format(SubscriptionUrls.GetLookup, userId, subscriptionPlanId, subscriptionStatusId);
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> SubscriptionPlans()
        {
            string url = SubscriptionPlanUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> SubscriptionStatuses()
        {
            string url = SubscriptionStatusUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> Tags()
        {
            string url = TagUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }
	
        [HttpGet]
        public async Task<JsonResult> Users()
        {
            string url = UsersUrls.GetLookup;
            var apiResult = await _api.GetAsync<GenericApiResponse<List<LookupDto>>>(url);
            return ReturnJsonResponse(apiResult, OperationTypes.GetList);
        }

    }
}
