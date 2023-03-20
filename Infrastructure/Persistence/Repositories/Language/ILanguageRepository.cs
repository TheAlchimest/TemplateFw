using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.Repositories
{
    public interface ILanguageRepository
    {
        Task<bool> CreateAsync(LanguageDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<LanguageInfoDto>> GetAllAsync(LanguageFilter filter);
        Task<PagedList<LanguageInfoDto>> GetAllInfoPagedAsync(LanguageFilter filter);
        Task<LanguageInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<LanguageDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(LanguageDto dto);
    }
}