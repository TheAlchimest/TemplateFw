using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ITagRepository
    {
        Task<bool> CreateAsync(TagDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<TagInfoDto>> GetAllAsync(TagFilter filter);
        Task<PagedList<TagInfoDto>> GetAllInfoPagedAsync(TagFilter filter);
        Task<TagInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<TagDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(TagDto dto);
    }
}