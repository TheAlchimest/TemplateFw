using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ITagService
    {
        Task<bool> CreateAsync(TagDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<TagInfoDto>> GetAllAsync(TagFilter filter);
        Task<PagedList<TagInfoDto>> GetAllInfoPagedAsync(TagFilter filter);
        Task<TagInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<TagDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(TagDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(TagFilter filter);
    }
}