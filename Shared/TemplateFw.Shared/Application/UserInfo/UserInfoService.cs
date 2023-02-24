using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Microsoft.Extensions.Primitives;
using TemplateFw.Shared.Helpers;
using TemplateFw.Shared.Configuration;
using TemplateFw.Shared.Domain.GenericResponse;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Memory;

namespace TemplateFw.Shared.Application.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SystemConfiguration _systemConfiguration;

        public UserInfoService(IHttpContextAccessor httpContextAccessor, SystemConfiguration systemConfiguration)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._systemConfiguration = systemConfiguration;
        }

        public string GetCurrentUserName()
        {
            var result = _httpContextAccessor.HttpContext.Request.Headers["user"];
            if (string.IsNullOrEmpty(result)) result = "Not Known User";
            return result;
        }
    }
}
