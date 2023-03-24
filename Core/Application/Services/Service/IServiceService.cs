using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IServiceService
    {
        Task<bool> CreateAsync(ServiceDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<LookupDto>> GetLookupAsync(int? portalId = null, int? serviceTypeId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(ServiceFilter filter);
        Task<List<ServiceInfoDto>> GetAllAsync(ServiceFilter filter);
        Task<PagedList<ServiceInfoDto>> GetAllInfoPagedAsync(ServiceFilter filter);
        Task<ServiceInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ServiceDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ServiceDto dto);
    }
}