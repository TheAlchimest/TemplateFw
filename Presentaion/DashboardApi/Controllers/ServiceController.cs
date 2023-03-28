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
    public class ServiceController : ApiControllerBase<ServiceController>
    {
        private readonly IServiceService serviceService;

        public ServiceController(ILogger<ServiceController> logger, IServiceService ServiceService)
            : base(logger)
        {
            serviceService = ServiceService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("save")]
        public async Task<ApiResponse> Save(ServiceDto dto)
        {
            if (dto.ServiceId == 0)
            {
                return await ApiResponse(() => serviceService.CreateAsync(dto), OperationTypes.Add);
            }
            else
            {
                return await ApiResponse(() => serviceService.UpdateAsync(dto), OperationTypes.Update);
            }
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<ServiceDto>> GetById(int id)
        {
            return await GenericApiResponse(() => serviceService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<ServiceInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => serviceService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<ServiceInfoDto>>> GetAll(ServiceFilter filter)
        {
            return await GenericApiResponse(() => serviceService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<ServiceInfoDto>>> GetPagedList(ServiceFilter filter)
        {
            return await GenericApiResponse(() => serviceService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => serviceService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup(int? serviceTypeId = null, int? portalId = null)
        {
            return await GenericApiResponse(() => serviceService.GetLookupAsync(serviceTypeId, portalId), OperationTypes.GetList);
        }
        
    }
}
