using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface ISubscriptionPlanService
    {
        Task<bool> CreateAsync(SubscriptionPlanDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<SubscriptionPlanInfoDto>> GetAllAsync(SubscriptionPlanFilter filter);
        Task<PagedList<SubscriptionPlanInfoDto>> GetAllInfoPagedAsync(SubscriptionPlanFilter filter);
        Task<SubscriptionPlanInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<SubscriptionPlanDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionPlanDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(SubscriptionPlanFilter filter);
    }
}