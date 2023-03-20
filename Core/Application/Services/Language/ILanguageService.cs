using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ILanguageService
    {
        Task<bool> CreateAsync(LanguageDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<LanguageInfoDto>> GetAllAsync(LanguageFilter filter);
        Task<PagedList<LanguageInfoDto>> GetAllInfoPagedAsync(LanguageFilter filter);
        Task<LanguageInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<LanguageDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(LanguageDto dto);
    }
}