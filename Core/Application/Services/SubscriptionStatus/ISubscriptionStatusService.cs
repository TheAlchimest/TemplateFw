using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ISubscriptionStatusService
    {
        Task<bool> CreateAsync(SubscriptionStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<SubscriptionStatusInfoDto>> GetAllAsync(SubscriptionStatusFilter filter);
        Task<PagedList<SubscriptionStatusInfoDto>> GetAllInfoPagedAsync(SubscriptionStatusFilter filter);
        Task<SubscriptionStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<SubscriptionStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionStatusDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(SubscriptionStatusFilter filter);
    }
}