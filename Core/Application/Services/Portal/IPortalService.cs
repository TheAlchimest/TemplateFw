using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IPortalService
    {
        Task<bool> CreateAsync(PortalDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<LookupDto>> GetAllAsLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(PortalFilter filter);
        Task<List<PortalInfoDto>> GetAllAsync(PortalFilter filter);
        Task<PagedList<PortalInfoDto>> GetAllInfoPagedAsync(PortalFilter filter);
        Task<PortalInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<PortalDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(PortalDto dto);
    }
}