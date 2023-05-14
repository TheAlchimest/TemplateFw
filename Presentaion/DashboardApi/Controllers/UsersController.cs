using Microsoft.AspNetCore.Mvc;
using TemplateFw.Application.Services;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Domain.Models;

namespace TemplateFw.DashboardApi.Controllers
{

    // [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ApiControllerBase<UsersController>
    {
        private readonly IUsersService usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService UsersService)
            : base(logger)
        {
            usersService = UsersService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(UsersDto dto)
        {
            return await ApiResponse(() => usersService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(UsersDto dto)
        {
             return await ApiResponse(() => usersService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<UsersDto>> GetById(int id)
        {
            return await GenericApiResponse(() => usersService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<UsersInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => usersService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<UsersInfoDto>>> GetAll(UsersFilter filter)
        {
            return await GenericApiResponse(() => usersService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<UsersInfoDto>>> GetPagedList(UsersFilter filter)
        {
            return await GenericApiResponse(() => usersService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => usersService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup()
        {
            return await GenericApiResponse(() => usersService.GetLookupAsync(), OperationTypes.GetList);
        }
        
    }
}
