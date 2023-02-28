using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Persistence.Repositories
{
    public interface IFaqRepository
    {
        Task<bool> DeleteAsync(int id, string user);
        Task<List<FaqInfoDto>> GetAllAsync(EnumLanguage lang = EnumLanguage.Arabic, int? portalId = null, int? serviceId = null);
        Task<Faq> GetOneByIdAsync(int id);
        Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<PagedList<FaqInfoDto>> GetPagedListAsync(FaqGridFilter filter);
        Task<PagedList<FaqInfoDto>> GetPageByPageAsync(FaqGridFilter filter);
        Task<bool> CreateAsync(Faq entity);
        Task<bool> UpdateAsync(FaqDto dto);
    }
}