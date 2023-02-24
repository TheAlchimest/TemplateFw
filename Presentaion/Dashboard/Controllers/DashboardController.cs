using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dashboard.Common.WebClientHelpers;
using TemplateFw.Shared.Domain.GenericResponse;
using Microsoft.AspNetCore.Authorization;
using Urls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.DashoardHomeUrls;
using LookupsUrls = Dashboard.Common.WebClientHelpers.InternalApiDictionary.LookupsUrls;


namespace TemplateFw.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        private readonly RequestUrlHelper _api = ApiRequestHelper.InternalAPI;
        private readonly RequestUrlHelper _accountsApi = ApiRequestHelper.AcountsAPI;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous, ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Response.StatusCode = 500;
            return View();
        }

        [AllowAnonymous, ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult UnauthorizedAction()
        {
            Response.StatusCode = 403;
            return View();
        }

        [AllowAnonymous, ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
