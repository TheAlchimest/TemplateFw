using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Shared.Helpers;
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.ServiceTypeUrls;

namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.ServiceType)]
    public class ServiceTypeController : WebBaseController<ServiceTypeController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;
        private readonly IValidator<ServiceTypeDto> _validator;

        public ServiceTypeController(IValidator<ServiceTypeDto> validator)
        {
            _validator = validator;
        }

    #region Add
    [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var dto = new ServiceTypeDto();
                ViewBag.ActionUrl = "/serviceType/create";
                return View("Save", dto);
    }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                id = StringCipher.Decrypt(id);
                string url = string.Format(Urls.GetOne, id);
                var apiResult = await _api.GetAsync<GenericApiResponse<ServiceTypeDto>>(url);
                ViewBag.ActionUrl = "/serviceType/update";
                return ReturnViewResponse(apiResult, OperationTypes.GetContent, "Save");
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }

        }

        #endregion

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ServiceTypeFilter filter = new ServiceTypeFilter();
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<ServiceTypeInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] ServiceTypeFilter filter)
        {
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<ServiceTypeInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceTypeDto dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return ReturnBadRequest(validationResult);
                }
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Create, dto);
                return ReturnJsonResponse(apiResult, OperationTypes.Add);
            }
            catch (System.Exception ex)
            {
                return ReturnJsonException(ex, OperationTypes.Add);
            }

        }
        #endregion

        #region Update
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ServiceTypeDto dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return ReturnBadRequest(validationResult);
                }
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Update, dto);
                return ReturnJsonResponse(apiResult, OperationTypes.Update);
            }
            catch (System.Exception ex)
            {
                return ReturnJsonException(ex, OperationTypes.Update);
            }
        }
        #endregion

        #region Delete

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ReturnBadRequest(OperationTypes.Delete);
                }
                string url = string.Format(Urls.Delete, id);
                var apiResult = await _api.PostAsync<ApiResponse>(url, id);
                return ReturnJsonResponse(apiResult, OperationTypes.Delete);
            }
            catch (System.Exception ex)
            {

                return ReturnJsonException(ex, OperationTypes.Delete);
            }

        }
        #endregion

    }
}
