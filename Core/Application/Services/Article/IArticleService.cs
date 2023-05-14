using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IArticleService
    {
        Task<bool> CreateAsync(ArticleDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ArticleInfoDto>> GetAllAsync(ArticleFilter filter);
        Task<PagedList<ArticleInfoDto>> GetAllInfoPagedAsync(ArticleFilter filter);
        Task<ArticleInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ArticleDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ArticleDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? authorId = null, int? categoryId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(ArticleFilter filter);
    }
}