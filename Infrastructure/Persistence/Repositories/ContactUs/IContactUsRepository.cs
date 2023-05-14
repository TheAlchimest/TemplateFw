using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IContactUsRepository
    {
        Task<bool> CreateAsync(ContactUsDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ContactUsInfoDto>> GetAllAsync(ContactUsFilter filter);
        Task<PagedList<ContactUsInfoDto>> GetAllInfoPagedAsync(ContactUsFilter filter);
        Task<ContactUsInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ContactUsDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ContactUsDto dto);
    }
}