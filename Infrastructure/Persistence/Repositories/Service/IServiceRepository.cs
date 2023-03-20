using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.Repositories
{
    public interface IServiceRepository
    {
        Task<bool> CreateAsync(ServiceDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ServiceInfoDto>> GetAllAsync(ServiceFilter filter);
        Task<PagedList<ServiceInfoDto>> GetAllInfoPagedAsync(ServiceFilter filter);
        Task<ServiceInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ServiceDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ServiceDto dto);
    }
}