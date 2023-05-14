using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IArticleRepository
    {
        Task<bool> CreateAsync(ArticleDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ArticleInfoDto>> GetAllAsync(ArticleFilter filter);
        Task<PagedList<ArticleInfoDto>> GetAllInfoPagedAsync(ArticleFilter filter);
        Task<ArticleInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ArticleDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ArticleDto dto);
    }
}