using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateFw.Application.Services;
using TemplateFw.Application.Services.Lookup;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Dtos.Dtos.Common;

namespace TemplateFw.DashboardApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class LookupController : ApiControllerBase<LookupController>
    {
        private readonly ILanguageService _languageService;
        private readonly ILookupService _lookupService;


        public LookupController(ILogger<LookupController> logger
            , ILanguageService languageService,
            ILookupService lookupService) : base(logger)
        {
            _languageService = languageService;
            _lookupService = lookupService;
        }


        //[HttpGet("languages")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //public async Task<List<LookupDto>> Languages()
        //{
        //    return await _languageService.GetAllAsync();
        //}
        [HttpGet("communicationtype")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<List<LookupDto>> CommunicationType()
        {
            List<LookupDto> list = new List<LookupDto>();
            list.Add(new LookupDto(1, "المعايير الموحدة وادارة الهوية"));
            list.Add(new LookupDto(2, "محرك انشاء النماذج"));
            list.Add(new LookupDto(3, "سحب النماذج"));
            return list;
        }


    }
}
