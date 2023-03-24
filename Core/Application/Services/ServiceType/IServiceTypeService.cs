using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IServiceTypeService
    {
        Task<bool> CreateAsync(ServiceTypeDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<LookupDto>> GetAllAsLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(ServiceTypeFilter filter);
        Task<List<ServiceTypeInfoDto>> GetAllAsync(ServiceTypeFilter filter);
        Task<PagedList<ServiceTypeInfoDto>> GetAllInfoPagedAsync(ServiceTypeFilter filter);
        Task<ServiceTypeInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ServiceTypeDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ServiceTypeDto dto);
    }
}