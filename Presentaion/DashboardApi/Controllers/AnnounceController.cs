using Microsoft.AspNetCore.Mvc;
using TemplateFw.Application.Services.Announces;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.DashboardApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnnounceController : ApiControllerBase<AnnounceController>
    {
        private readonly IAnnounceService _service;

        public AnnounceController(ILogger<AnnounceController> logger, IAnnounceService announceService)
           : base(logger)
        {
            _service = announceService;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("save")]
        public async Task<ApiResponse> Save(AnnounceRequestDto dto)
        {
            OperationTypes operation = (dto.Id == 0) ? OperationTypes.Add : OperationTypes.Update;
            return await ApiResponse(() => _service.SaveAsync(dto), operation);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<VwAnnounceFullData>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => _service.FullDataByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }


        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<AnnounceResponseDto>> GetById(int id)
        {
            return await GenericApiResponse(() => _service.GetByIdAsync(id), OperationTypes.GetOne);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<PagedList<VwAnnounceFullData>>> GetAll(AnnounceGridFilter filter)
        {
            return await GenericApiResponse(() => _service.GetPagedListAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => _service.DeleteAsync(id), OperationTypes.Delete);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("activate/{id}")]
        public async Task<ApiResponse> Activate(int id)
        {
            return await ApiResponse(() => _service.ActivateAsync(id), OperationTypes.Activate);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("deactivate/{id}")]
        public async Task<ApiResponse> Deactivate(int id)
        {
            return await ApiResponse(() => _service.DeactivateAsync(id), OperationTypes.Deactivate);
        }

    }
}
