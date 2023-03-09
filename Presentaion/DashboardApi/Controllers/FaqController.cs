using Microsoft.AspNetCore.Mvc;
using TemplateFw.Application.Services.FAQ;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.DashboardApi.Controllers
{

    // [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FaqController : ApiControllerBase<FaqController>
    {
        private readonly IFaqService _faqService;

        public FaqController(ILogger<FaqController> logger, IFaqService faqService)
            : base(logger)
        {
            _faqService = faqService;
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
                return await ApiResponse(() => _faqService.CreateAsync(dto), OperationTypes.Add);
            }
            else
            {
                return await ApiResponse(() => _faqService.UpdateAsync(dto), OperationTypes.Update);
            }
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<FaqDto>> GetById(int id)
        {
            return await GenericApiResponse(() => _faqService.GetOneByIdAsync(200000), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<FaqInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => _faqService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<PagedList<FaqInfoDto>>> GetAll(FaqGridFilter filter)
        {
            return await GenericApiResponse(() => _faqService.GetPagedListAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<FaqInfoDto>>> GetPagedList(FaqGridFilter filter)
        {
            return await GenericApiResponse(() => _faqService.GetPageByPageAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => _faqService.DeleteAsync(id), OperationTypes.Delete);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallview")]
        public async Task<GenericApiResponse<List<FaqInfoDto>>> GetAllView(FaqGridFilter filter)
        {
            return await GenericApiResponse(() => _faqService.GetAllAsync(filter), OperationTypes.GetList);
        }
    }
}
