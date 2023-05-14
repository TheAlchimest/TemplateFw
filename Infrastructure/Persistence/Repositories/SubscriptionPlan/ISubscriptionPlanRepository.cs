using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ISubscriptionPlanRepository
    {
        Task<bool> CreateAsync(SubscriptionPlanDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<SubscriptionPlanInfoDto>> GetAllAsync(SubscriptionPlanFilter filter);
        Task<PagedList<SubscriptionPlanInfoDto>> GetAllInfoPagedAsync(SubscriptionPlanFilter filter);
        Task<SubscriptionPlanInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<SubscriptionPlanDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionPlanDto dto);
    }
}