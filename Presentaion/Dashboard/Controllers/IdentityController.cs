using Dashboard.Common.WebClientHelpers;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Dtos.Identity;
using TemplateFw.Shared.Dtos.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateFw.Shared.Helpers;
using TemplateFw.Shared.Domain.Enums;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.AdminUrls;
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;


namespace TemplateFw.Dashboard.Controllers
{
    [Authorize(Roles = RoleProvider.SUPER_ADMIN)]
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
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var filter = new PaginationParameter();
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<AdminDto>>>(Urls.GetAll, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }
        }


        [HttpGet]
        public async Task<IActionResult> IndexContent([FromQuery] GridFilter filter)
        {
            try
            {
                var apiResult = await _api.PostAsync<GenericApiResponse<PagedList<AdminDto>>>
                 (Urls.GetAll, filter);
                return ReturnViewResponse(apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
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
                return ReturnViewResponse("Save", apiResult, OperationTypes.GetContent);
            }
            catch (System.Exception ex)
            {
                return ReturnViewResponse(ex, OperationTypes.GetContent);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AdminDto dto)
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
