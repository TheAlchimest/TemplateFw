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
    public class SubscriptionPlanController : ApiControllerBase<SubscriptionPlanController>
    {
        private readonly ISubscriptionPlanService subscriptionPlanService;

        public SubscriptionPlanController(ILogger<SubscriptionPlanController> logger, ISubscriptionPlanService SubscriptionPlanService)
            : base(logger)
        {
            subscriptionPlanService = SubscriptionPlanService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(SubscriptionPlanDto dto)
        {
            return await ApiResponse(() => subscriptionPlanService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(SubscriptionPlanDto dto)
        {
             return await ApiResponse(() => subscriptionPlanService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<SubscriptionPlanDto>> GetById(int id)
        {
            return await GenericApiResponse(() => subscriptionPlanService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<SubscriptionPlanInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => subscriptionPlanService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<SubscriptionPlanInfoDto>>> GetAll(SubscriptionPlanFilter filter)
        {
            return await GenericApiResponse(() => subscriptionPlanService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<SubscriptionPlanInfoDto>>> GetPagedList(SubscriptionPlanFilter filter)
        {
            return await GenericApiResponse(() => subscriptionPlanService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => subscriptionPlanService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup()
        {
            return await GenericApiResponse(() => subscriptionPlanService.GetLookupAsync(), OperationTypes.GetList);
        }
        
    }
}
