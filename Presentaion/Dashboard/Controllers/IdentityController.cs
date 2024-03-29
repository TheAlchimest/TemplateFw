﻿using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Shared.Dtos.Identity;
using TemplateFw.Shared.Helpers;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.AdminUrls;


namespace TemplateFw.Dashboard.Controllers
{
    //[Authorize(Roles = RoleProvider.SUPER_ADMIN)]
    public class IdentityController : WebBaseController<IdentityController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                return View("Save", new AdminDto());
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var filter = new PaginationFilter();
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<AdminDto>>>(Urls.GetAll, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }


        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] FaqFilter filter)
        {
            try
            {
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<AdminDto>>>
                 (Urls.GetAll, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                id = StringCipher.Decrypt(id);
                string url = string.Format(Urls.GetOne, id);
                var apiResult = await _api.GetAsync<GenericApiResponse<AdminDto>>(url);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent, "Save");
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AdminDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ReturnBadRequest(ModelState);
                }
                OperationTypes operation = (dto.Id > 0) ? OperationTypes.Update : OperationTypes.Add;
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Save, dto);
                return ReturnJsonResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                OperationTypes operation = (dto.Id > 0) ? OperationTypes.Update : OperationTypes.Add;
                return ReturnJsonException(ex, operation);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ReturnBadRequest(ModelState);
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


        [HttpGet]
        public async Task<string> GetFullName(string id)
        {
            try
            {
                string url = string.Format(Urls.Getfullname, id);
                var apiResult = await _api.GetAsync<string>(url);
                return apiResult;
            }
            catch (System.Exception ex)
            {
                id = StringCipher.Decrypt(id);
                return id;
            }
        }
    }
}
