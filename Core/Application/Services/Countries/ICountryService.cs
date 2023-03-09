using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;

namespace TemplateFw.Application.Services.Countries
{
    public interface ICountryService
    {
        Task<List<LookupDto>> GetAllListAsync(EnumLanguage language);

        Task<List<LookupDto>> GetNonSaudiListAsync(EnumLanguage language);
    }
}
