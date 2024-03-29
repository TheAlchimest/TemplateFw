﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IServiceTypeRepository
    {
        Task<bool> CreateAsync(ServiceTypeDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<ServiceTypeInfoDto>> GetAllAsync(ServiceTypeFilter filter);
        Task<PagedList<ServiceTypeInfoDto>> GetAllInfoPagedAsync(ServiceTypeFilter filter);
        Task<ServiceTypeInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<ServiceTypeDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(ServiceTypeDto dto);
    }
}