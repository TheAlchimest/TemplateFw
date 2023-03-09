using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos.Dtos.Common;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ILanguageRepository
    {
        Task<List<LookupDto>> GetAllLanguagesAsync();
    }
}