using System.Threading.Tasks;
using TemplateFw.Domain.Models;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IActionLogRepository
    {
        Task<ActionLog> InsertAsync(ActionLog entity);
    }
}
