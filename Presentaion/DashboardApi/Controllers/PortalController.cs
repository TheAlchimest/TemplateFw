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
    public class PortalController : ApiControllerBase<PortalController>
    {
        private readonly IPortalService portalService;

        public PortalController(ILogger<PortalController> logger, IPortalService PortalService)
            : base(logger)
        {
            portalService = PortalService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("save")]
        public async Task<ApiResponse> Save(PortalDto dto)
        {
            if (dto.PortalId == 0)
            {
                return await ApiResponse(() => portalService.CreateAsync(dto), OperationTypes.Add);
            }
            else
            {
                return await ApiResponse(() => portalService.UpdateAsync(dto), OperationTypes.Update);
            }
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<PortalDto>> GetById(int id)
        {
            return await GenericApiResponse(() => portalService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<PortalInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => portalService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<PortalInfoDto>>> GetAll(PortalFilter filter)
        {
            return await GenericApiResponse(() => portalService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<PortalInfoDto>>> GetPagedList(PortalFilter filter)
        {
            return await GenericApiResponse(() => portalService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => portalService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        
    }
}
