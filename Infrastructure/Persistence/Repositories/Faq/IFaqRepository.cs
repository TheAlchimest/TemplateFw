using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.Repositories
{
    public interface IFaqRepository
    {
        Task<bool> CreateAsync(FaqDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<FaqInfoDto>> GetAllAsync(FaqFilter filter);
        Task<PagedList<FaqInfoDto>> GetAllInfoPagedAsync(FaqFilter filter);
        Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<FaqDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(FaqDto dto);
    }
}