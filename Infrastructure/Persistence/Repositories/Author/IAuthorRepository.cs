using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IAuthorRepository
    {
        Task<bool> CreateAsync(AuthorDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<AuthorInfoDto>> GetAllAsync(AuthorFilter filter);
        Task<PagedList<AuthorInfoDto>> GetAllInfoPagedAsync(AuthorFilter filter);
        Task<AuthorInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<AuthorDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(AuthorDto dto);
    }
}