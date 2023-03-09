using System;
using System.Threading.Tasks;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IAnnounceRepository
    {
        Task<PagedList<VwAnnounceFullData>> GetPagedListAsync(AnnounceGridFilter filter);
        Task<Announce> InsertAsync(Announce entity);
        Task<bool> UpdateAsync(AnnounceRequestDto dto, string user);
        Task<bool> DeleteAsync(int id, string user);
        Task<bool> ActivateAsync(int id, string user);
        Task<bool> DeactivateAsync(int id, string user);
        Task<bool> PreventViewAgainAsync(int announceId, Guid userId);
        Task<Announce> GetByIdAsync(int id);
        Task<VwAnnounceFullData> FullDataByIdAsync(int id, EnumLanguage lang);
        Task<VwAnnounceFullData> GetClientPortalAnnounceAsync(int portalId, Guid userId);
    }
}