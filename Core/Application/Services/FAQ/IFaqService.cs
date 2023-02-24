using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Shared.Dtos.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateFw.Application.Services.FAQ
{
    public interface IFaqService
    {
        Task<bool> CreateAsync(FaqDto model);
        Task<bool> UpdateAsync(FaqDto dto);
        Task<bool> DeleteAsync(int id);
        Task<PagedList<FaqInfoDto>> GetPagedListAsync(FaqGridFilter filter);
        Task<List<FaqInfoDto>> GetAllAsync(FaqGridFilter filter);
        Task<FaqDto> GetOneByIdAsync(int id);
        Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
    }
}
