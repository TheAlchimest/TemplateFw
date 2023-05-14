using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ISubscriptionStatusRepository
    {
        Task<bool> CreateAsync(SubscriptionStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<SubscriptionStatusInfoDto>> GetAllAsync(SubscriptionStatusFilter filter);
        Task<PagedList<SubscriptionStatusInfoDto>> GetAllInfoPagedAsync(SubscriptionStatusFilter filter);
        Task<SubscriptionStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<SubscriptionStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(SubscriptionStatusDto dto);
    }
}