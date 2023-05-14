using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ICommentService
    {
        Task<bool> CreateAsync(CommentDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<CommentInfoDto>> GetAllAsync(CommentFilter filter);
        Task<PagedList<CommentInfoDto>> GetAllInfoPagedAsync(CommentFilter filter);
        Task<CommentInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<CommentDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(CommentDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? articleId = null, int? userId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(CommentFilter filter);
    }
}