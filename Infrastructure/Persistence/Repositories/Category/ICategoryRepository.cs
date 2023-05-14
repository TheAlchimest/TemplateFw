using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(CategoryDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<CategoryInfoDto>> GetAllAsync(CategoryFilter filter);
        Task<PagedList<CategoryInfoDto>> GetAllInfoPagedAsync(CategoryFilter filter);
        Task<CategoryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<CategoryDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(CategoryDto dto);
    }
}