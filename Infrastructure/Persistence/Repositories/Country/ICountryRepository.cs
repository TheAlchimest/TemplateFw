using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.Repositories
{
    public interface ICountryRepository
    {
        Task<bool> CreateAsync(CountryDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<CountryInfoDto>> GetAllAsync(CountryFilter filter);
        Task<PagedList<CountryInfoDto>> GetAllInfoPagedAsync(CountryFilter filter);
        Task<CountryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<CountryDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(CountryDto dto);
    }
}