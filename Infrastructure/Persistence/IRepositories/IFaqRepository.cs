using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Shared.Dtos.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IFaqRepository
    {
        //Task<IPagedList<VwFaqFullData>> GetPagedListAsync(FaqQueryParameter filter);
        Task<bool> InsertAsync(Faq entity);
        Task<bool> UpdateAsync(FaqRequestDto dto, string user);
        Task<bool> DeleteAsync(int id, string user);
        Task<Faq> GetByIdAsync(int id);
        Task<VwFaqFullData> FullDataByIdAsync(int id, EnumLanguage lang);

        Task<PagedList<VwFaqFullData>> GetPagedListAsync(FaqGridFilter filter);
        Task<List<VwFaqFullData>> GetAllListAsync(FaqGridFilter filter);
    }
}