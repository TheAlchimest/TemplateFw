using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ISubscriptionService
    {
        Task<bool> CreateAsync(SubscriptionDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<SubscriptionInfoDto>> GetAllAsync(SubscriptionFilter filter);
        Task<PagedList<SubscriptionInfoDto>> GetAllInfoPagedAsync(SubscriptionFilter filter);
        Task<SubscriptionInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<SubscriptionDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? userId = null, int? subscriptionPlanId = null, int? subscriptionStatusId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(SubscriptionFilter filter);
    }
}