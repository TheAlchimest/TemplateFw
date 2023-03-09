using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos.Dtos.Common;

namespace TemplateFw.Application.Services.Languages
{
    public interface ILanguageService
    {
        Task<List<LookupDto>> GetAllLanguagesAsync();
    }
}
