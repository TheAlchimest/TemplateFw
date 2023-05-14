using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IPaymentRepository
    {
        Task<bool> CreateAsync(PaymentDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<PaymentInfoDto>> GetAllAsync(PaymentFilter filter);
        Task<PagedList<PaymentInfoDto>> GetAllInfoPagedAsync(PaymentFilter filter);
        Task<PaymentInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<PaymentDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(PaymentDto dto);
    }
}