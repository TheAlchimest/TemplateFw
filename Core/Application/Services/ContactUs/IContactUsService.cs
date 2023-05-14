using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IContactUsService
    {
        Task<bool> CreateAsync(ContactUsDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<ContactUsInfoDto>> GetAllAsync(ContactUsFilter filter);
        Task<PagedList<ContactUsInfoDto>> GetAllInfoPagedAsync(ContactUsFilter filter);
        Task<ContactUsInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<ContactUsDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ContactUsDto dto);
        Task<List<LookupDto>> GetLookupAsync();
        Task<List<LookupDto>> GetAllAsLookupAsync(ContactUsFilter filter);
    }
}