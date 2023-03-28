using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IFaqService
    {
        Task<bool> CreateAsync(FaqDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<FaqInfoDto>> GetAllAsync(FaqFilter filter);
        Task<PagedList<FaqInfoDto>> GetAllInfoPagedAsync(FaqFilter filter);
        Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<FaqDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(FaqDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? portalId = null, int? serviceId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(FaqFilter filter);
    }
}