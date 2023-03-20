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
    public class FaqController : ApiControllerBase<FaqController>
    {
        private readonly IFaqService faqService;

        public FaqController(ILogger<FaqController> logger, IFaqService FaqService)
            : base(logger)
        {
            faqService = FaqService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("save")]
        public async Task<ApiResponse> Save(FaqDto dto)
        {
            if (dto.FaqId == 0)
            {
                return await ApiResponse(() => faqService.CreateAsync(dto), OperationTypes.Add);
            }
            else
            {
                return await ApiResponse(() => faqService.UpdateAsync(dto), OperationTypes.Update);
            }
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<FaqDto>> GetById(int id)
        {
            return await GenericApiResponse(() => faqService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<FaqInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => faqService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<FaqInfoDto>>> GetAll(FaqFilter filter)
        {
            return await GenericApiResponse(() => faqService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<FaqInfoDto>>> GetPagedList(FaqFilter filter)
        {
            return await GenericApiResponse(() => faqService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => faqService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        
    }
}
