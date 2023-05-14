using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IAuthorService
    {
        Task<bool> CreateAsync(AuthorDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<AuthorInfoDto>> GetAllAsync(AuthorFilter filter);
        Task<PagedList<AuthorInfoDto>> GetAllInfoPagedAsync(AuthorFilter filter);
        Task<AuthorInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<AuthorDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(AuthorDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? countryId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(AuthorFilter filter);
    }
}