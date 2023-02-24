using TemplateFw.Dtos.Dtos.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ILanguageRepository
    {
        Task<List<LookupDto>> GetAllLanguagesAsync();
    }
}