﻿using Microsoft.AspNetCore.Mvc;
using TemplateFw.Dtos.FAQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Common.WebClientHelpers;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using Microsoft.AspNetCore.Authorization;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Shared.Helpers;
using TemplateFw.Shared.Domain.Enums;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.FaqsUrls;
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;

namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.FAQS_ADMIN)]
    public class FaqController : WebBaseController<FaqController>
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
                FaqDto dto = new FaqDto();
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
            try
            {
                FaqGridFilter filter = new FaqGridFilter();
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<FaqInfoDto>>>(Urls.GetAll, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }

        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] GridFilter filter)
        {
            try
            {
                string apiUrl = Urls.GetAll;
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<FaqInfoDto>>>(apiUrl, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
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
                var languages = await _api.GetAsync<List<LookupDto>>(LookupsUrls.Languages);
                ViewBag.Languages = languages;
                string url = string.Format(Urls.GetOne, id);
                var apiResult = await _api.GetAsync<GenericApiResponse<FaqDto>>(url);
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
        public async Task<IActionResult> Save([FromBody]FaqDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ReturnInvalidModel(ModelState);
                }
                OperationTypes operation = (dto.FaqId > 0) ? OperationTypes.Update : OperationTypes.Add;
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Save, dto);
                return ReturnJsonResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                OperationTypes operation = (dto.FaqId > 0) ? OperationTypes.Update : OperationTypes.Add;
                return ReturnJsonResponse(ex,operation);
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

                return ReturnJsonResponse(ex, OperationTypes.Delete );
            }
           
        }
        #endregion

    }
}
