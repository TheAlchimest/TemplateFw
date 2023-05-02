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
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.FaqUrls;
using FluentValidation;
using FluentValidation.Results;
using Azure;

namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.Faq)]
    public class FaqController : WebBaseController<FaqController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;
        private readonly IValidator<FaqDto> _validator;

        public FaqController(IValidator<FaqDto> validator)
        {
            _validator = validator;
        }

        #region Add

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var languages = await _api.GetAsync<List<LookupDto>>(LookupsUrls.Languages);
                ViewBag.Languages = languages;
                FaqDto dto = new FaqDto();
                return View("Save", dto);
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
            FaqFilter filter = new FaqFilter();
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<FaqInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] FaqFilter filter)
        {
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<FaqInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                id = StringCipher.Decrypt(id);
                var languages = await _api.GetAsync<List<LookupDto>>(LookupsUrls.Languages);
                ViewBag.Languages = languages;
                string url = string.Format(Urls.GetOne, id);
                var apiResult = await _api.GetAsync<GenericApiResponse<FaqDto>>(url);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent, "Save");
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }

        }

        #endregion

        #region Save


        [HttpPost]
        public async Task<IActionResult> Save([FromBody] FaqDto dto)
        {
            try
            {
                var validationResult = _validator.Validate(dto);
                if (!validationResult.IsValid)
                {
                    return ReturnBadRequest(validationResult);
                    
                }

                OperationTypes operation = (dto.FaqId > 0) ? OperationTypes.Update : OperationTypes.Add;
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Save, dto);
                return ReturnJsonResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                OperationTypes operation = (dto.FaqId > 0) ? OperationTypes.Update : OperationTypes.Add;
                return ReturnJsonException(ex, operation);
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
