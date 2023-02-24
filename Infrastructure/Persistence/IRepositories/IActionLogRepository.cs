using TemplateFw.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IActionLogRepository
    {
        Task<ActionLog> InsertAsync(ActionLog entity);
    }
}
