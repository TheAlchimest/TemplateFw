using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IUsersService
    {
        Task<bool> CreateAsync(UsersDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<UsersInfoDto>> GetAllAsync(UsersFilter filter);
        Task<PagedList<UsersInfoDto>> GetAllInfoPagedAsync(UsersFilter filter);
        Task<UsersInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<UsersDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(UsersDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(UsersFilter filter);
    }
}