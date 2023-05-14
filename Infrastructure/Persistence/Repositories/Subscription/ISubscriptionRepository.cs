using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ISubscriptionRepository
    {
        Task<bool> CreateAsync(SubscriptionDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<SubscriptionInfoDto>> GetAllAsync(SubscriptionFilter filter);
        Task<PagedList<SubscriptionInfoDto>> GetAllInfoPagedAsync(SubscriptionFilter filter);
        Task<SubscriptionInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<SubscriptionDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionDto dto);
    }
}