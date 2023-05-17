using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IModelStatusRepository
    {
        Task<bool> CreateAsync(ModelStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ModelStatusInfoDto>> GetAllAsync(ModelStatusFilter filter);
        Task<PagedList<ModelStatusInfoDto>> GetAllInfoPagedAsync(ModelStatusFilter filter);
        Task<ModelStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ModelStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ModelStatusDto dto);
    }
}