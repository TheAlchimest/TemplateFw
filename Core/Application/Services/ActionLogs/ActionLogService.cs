using AutoMapper;
using AutoMapper.Configuration;
using TemplateFw.Domain.Models;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Shared.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TemplateFw.Domain.Models.ActionLog;

namespace TemplateFw.Application.Services.ActionLogs
{
    public class ActionLogService : BaseService, IActionLogService
    {
        private readonly IActionLogRepository _repository;
        private readonly IUserInfoService _userInfoService;

        public ActionLogService(IActionLogRepository repository, IMapper mapper,
            IUserInfoService userInfoService)
            : base(mapper, userInfoService)
        {
            this._repository = repository;
            this._userInfoService = userInfoService;
        }

        public async Task SaveAction(ActionLogActionType type, string token, string request, string response)
        {
            var userId = Guid.Empty;
            var userNumber = "";
            var userName = _userInfoService.GetCurrentUserName();
            var entity = new ActionLog(userId, userNumber, userName, token, type, request, response);
            await _repository.InsertAsync(entity);

        }
    }
}
