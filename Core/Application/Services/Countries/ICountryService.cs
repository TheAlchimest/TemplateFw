using TemplateFw.Domain.Models.Countries;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Application.Services.Countries
{
    public interface ICountryService
    {
        Task<List<LookupDto>> GetAllListAsync(EnumLanguage language);

        Task<List<LookupDto>> GetNonSaudiListAsync(EnumLanguage language);
    }
}
