using Dashboard.Common.WebClientHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Shared.Helpers;
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.AnnouncesUrls;

namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.ANNOUNCING_ADMIN)]
    public class AnnounceController : WebBaseController<AnnounceController>
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
                AnnounceResponseDto dto = new AnnounceResponseDto();
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
        public async Task<IActionResult> Index([FromQuery] AnnounceGridFilter filter)
        {
            try
            {
                ViewBag.searchURL = "/Announce/IndexContent";
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<VwAnnounceFullData>>>
                    (Urls.GetAll, filter);
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
        public async Task<IActionResult> IndexContent([FromQuery] AnnounceGridFilter filter)
        {
            try
            {
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<VwAnnounceFullData>>>(Urls.GetAll, filter);
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
                var apiResult = await _api.GetAsync<GenericApiResponse<AnnounceResponseDto>>(url);
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
        public async Task<IActionResult> Save([FromBody] AnnounceRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ReturnInvalidModel(ModelState);
                }
                OperationTypes operation = (dto.Id > 0) ? OperationTypes.Update : OperationTypes.Add;
                var apiResult = await _api.PostAsync<ApiResponse>(Urls.Save, dto);
                return ReturnJsonResponse(apiResult, operation);
            }
            catch (System.Exception ex)
            {
                OperationTypes operation = (dto.Id > 0) ? OperationTypes.Update : OperationTypes.Add;
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
                //id = StringCipher.Decrypt(id);
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

            //return Ok(result);
        }
        #endregion

        #region Activate



        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {

            try
            {
                //id = StringCipher.Decrypt(id);
                if (id <= 0)
                {
                    return ReturnInvalidModel(ModelState);
                }

                string url = string.Format(Urls.Activate, id);
                var apiResult = await _api.PostAsync<ApiResponse>(url, id);
                return ReturnJsonResponse(apiResult, OperationTypes.Activate);
            }
            catch (System.Exception ex)
            {

                return ReturnJsonResponse(ex, OperationTypes.Activate);
            }

        }
        #endregion

        #region Deactivate

        [HttpPost]
        public async Task<IActionResult> Deactivate(int id)
        {
            try
            {
                //id = StringCipher.Decrypt(id);
                if (id <= 0)
                {
                    return ReturnInvalidModel(ModelState);
                }
                string url = string.Format(Urls.Deactivate, id);
                var apiResult = await _api.PostAsync<ApiResponse>(url, id);
                return ReturnJsonResponse(apiResult, OperationTypes.Deactivate);
            }
            catch (System.Exception ex)
            {

                return ReturnJsonResponse(ex, OperationTypes.Deactivate);
            }
        }
        #endregion



    }
}
