using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IModelRepository
    {
        Task<bool> CreateAsync(ModelDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ModelInfoDto>> GetAllAsync(ModelFilter filter);
        Task<PagedList<ModelInfoDto>> GetAllInfoPagedAsync(ModelFilter filter);
        Task<ModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ModelDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ModelDto dto);
    }
}