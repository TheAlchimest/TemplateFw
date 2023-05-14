using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IUsersRepository
    {
        Task<bool> CreateAsync(UsersDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<UsersInfoDto>> GetAllAsync(UsersFilter filter);
        Task<PagedList<UsersInfoDto>> GetAllInfoPagedAsync(UsersFilter filter);
        Task<UsersInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<UsersDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(UsersDto dto);
    }
}