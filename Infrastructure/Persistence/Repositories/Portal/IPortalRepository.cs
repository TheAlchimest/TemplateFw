﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos;
using TemplateFw.Dtos.Common;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Persistence.IRepositories
{
    public interface IPortalRepository
    {
        Task<bool> CreateAsync(PortalDto dto);
        Task<bool> DeletePermanentlyAsync(int id);
        Task<bool> DeleteVirtuallyAsync(int id, string user);
        Task<List<PortalInfoDto>> GetAllAsync(PortalFilter filter);
        Task<PagedList<PortalInfoDto>> GetAllInfoPagedAsync(PortalFilter filter);
        Task<PortalInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic);
        Task<PortalDto> GetOneByIdAsync(int id);
        Task<bool> UpdateAsync(PortalDto dto);
    }
}