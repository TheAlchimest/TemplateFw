using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services
{
    public interface IPaymentService
    {
        Task<bool> CreateAsync(PaymentDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id);
        Task<List<PaymentInfoDto>> GetAllAsync(PaymentFilter filter);
        Task<PagedList<PaymentInfoDto>> GetAllInfoPagedAsync(PaymentFilter filter);
        Task<PaymentInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang);
        Task<PaymentDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(PaymentDto dto);
        Task<List<LookupDto>> GetLookupAsync(int? subscriptionId = null);
        Task<List<LookupDto>> GetAllAsLookupAsync(PaymentFilter filter);
    }
}