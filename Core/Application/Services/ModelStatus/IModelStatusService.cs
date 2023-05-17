using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IModelStatusService
    {
        Task<bool> CreateAsync(ModelStatusDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ModelStatusInfoDto>> GetAllAsync(ModelStatusFilter filter);
        Task<PagedList<ModelStatusInfoDto>> GetAllInfoPagedAsync(ModelStatusFilter filter);
        Task<ModelStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ModelStatusDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ModelStatusDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(ModelStatusFilter filter);
    }
}