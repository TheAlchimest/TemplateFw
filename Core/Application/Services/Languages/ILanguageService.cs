using TemplateFw.Dtos.Dtos.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Application.Services.Languages
{
    public interface ILanguageService 
    {
        Task<List<LookupDto>> GetAllLanguagesAsync();
    }
}
