using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IModelService
    {
        Task<bool> CreateAsync(ModelDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ModelInfoDto>> GetAllAsync(ModelFilter filter);
        Task<PagedList<ModelInfoDto>> GetAllInfoPagedAsync(ModelFilter filter);
        Task<ModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ModelDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ModelDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? countryId = null, int? categoryId = null, int? portalId = null, int? serviceId = null, int? modelStatusId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(ModelFilter filter);
    }
}