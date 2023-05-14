using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategoryDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<CategoryInfoDto>> GetAllAsync(CategoryFilter filter);
        Task<PagedList<CategoryInfoDto>> GetAllInfoPagedAsync(CategoryFilter filter);
        Task<CategoryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<CategoryDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(CategoryDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(CategoryFilter filter);
    }
}