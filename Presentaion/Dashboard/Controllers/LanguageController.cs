﻿using Dashboard.Common.WebClientHelpers;
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
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LanguageUrls;

namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.Language)]
    public class LanguageController : WebBaseController<LanguageController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;

        #region Add

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var languages = await _api.GetAsync<List<LookupDto>>(LookupsUrls.Languages);
                ViewBag.Languages = languages;
                LanguageDto dto = new LanguageDto();
                return View("Save", dto);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }
        }
        #endregion

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            LanguageFilter filter = new LanguageFilter();
            return await ReturnViewResponse<GenericApiResponse<PagedList<LanguageInfoDto>>>(_api, Urls.GetPaged, filter, OperationTypes.GetContent);
        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] LanguageFilter filter)
        {
            return await ReturnViewResponse<GenericApiResponse<PagedList<LanguageInfoDto>>>(_api, Urls.GetPaged, filter, OperationTypes.GetContent);
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
                var apiResult = await _api.GetAsync<GenericApiResponse<LanguageDto>>(url);
                return ReturnViewResponse("Save", apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }

        }

        #endregion

        #region Save


        [HttpPost]
        public async Task<IActionResult> Save([FromBody] LanguageDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ReturnInvalidModel(ModelState);
                }
                OperationTypes operation = (dto.LanguageId > 0) ? OperationTypes.Update : OperationTypes.Add;
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Save, dto);
                return ReturnJsonResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                OperationTypes operation = (dto.LanguageId > 0) ? OperationTypes.Update : OperationTypes.Add;
                return ReturnJsonResponse(ex, operation);
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
                    return ReturnInvalidModel(ModelState);
                }
                string url = string.Format(Urls.Delete, id);
                var apiResult = await _api.PostAsync<ApiResponse>(url, id);
                return ReturnJsonResponse(apiResult, OperationTypes.Delete);
            }
            catch (System.Exception ex)
            {

                return ReturnJsonResponse(ex, OperationTypes.Delete);
            }

        }
        #endregion

    }
}
