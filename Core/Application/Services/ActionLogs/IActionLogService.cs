using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TemplateFw.Domain.Models.ActionLog;

namespace TemplateFw.Application.Services.ActionLogs
{
    public interface IActionLogService
    {
        Task SaveAction(ActionLogActionType type, string token, string request, string response);
    }
}
