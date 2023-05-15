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

using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.TagUrls;

namespace TemplateFw.Dashboard.Controllers
{
    //[Authorize(Roles = RoleProvider.Tag)]
    public class TagController : WebBaseController<TagController>
    {
        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;
        private readonly TagDtoInsertValidator _insertValidator;
        private readonly TagDtoUpdateValidator _updateValidator;

        public  TagController(TagDtoInsertValidator validator, TagDtoUpdateValidator updateValidator)
        {
            _insertValidator = validator;
            _updateValidator = updateValidator;
        }

    #region Add
    [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                ViewBag.ActionUrl = "/tag/create";
                return View("Save");
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
                var apiResult = await _api.GetAsync<GenericApiResponse<TagDto>>(url);
                ViewBag.ActionUrl = "/tag/update";
                ViewBag.IsUpdateMode = true;
                return ReturnViewResponse(apiResult, OperationTypes.GetContent, "Save");
            }
            catch (System.Exception ex)
            {
                return ReturnViewException(ex, OperationTypes.GetContent);
            }

        }

        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagDto dto)
        {
            try
            {
                var validationResult = _insertValidator.Validate(dto);
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
        public async Task<IActionResult> Update([FromBody] TagDto dto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(dto);
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

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TagFilter filter = new TagFilter();
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<TagInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
        }
        #endregion

        #region IndexContent

        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] TagFilter filter)
        {
            var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<TagInfoDto>>>(Urls.GetPaged, filter);
            return ReturnViewResponse(apiResult, OperationTypes.GetContent);
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
