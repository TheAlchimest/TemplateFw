using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateFw.Application.Services.Languages;
using TemplateFw.Dtos.Dtos.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Shared.Helpers;
using TemplateFw.Application.Services.Lookup;
using Microsoft.AspNetCore.Authorization;

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


        [HttpGet("languages")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<List<LookupDto>> Languages()
        {
            return await _languageService.GetAllLanguagesAsync();
        }
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
