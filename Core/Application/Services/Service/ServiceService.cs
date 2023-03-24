﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Dtos.Dtos.Common;
using System.Linq;

namespace TemplateFw.Application.Services
{
    public class ServiceService : BaseService, IServiceService
    {
        #region Fields
        private readonly IServiceRepository _repository;
        #endregion

        #region Constructor
        public ServiceService(IServiceRepository repository, IMapper mapper, IUserInfoService userInfoService) : base(mapper, userInfoService)
        {
            _repository = repository;
        }
        #endregion

        #region CreateAsync
        public async Task<bool> CreateAsync(ServiceDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.CreatedBy = user;
            return await _repository.CreateAsync(dto);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ServiceDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.LastModifiedBy = user;
            return await _repository.UpdateAsync(dto);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            return await _repository.DeletePermanentlyAsync(id);
        }
        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id)
        {
            string user = _userInfoService.GetCurrentUserName();
            return await _repository.DeleteVirtuallyAsync(id, user);
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ServiceDto> GetOneByIdAsync(int id)
        {
            var entity = await _repository.GetOneByIdAsync(id);
            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }
            return entity;
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ServiceInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang)
        {
            var entity = await _repository.GetInfoByIdAsync(id, lang);
            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }
            return entity;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ServiceInfoDto>> GetAllAsync(ServiceFilter filter)
        {
            var list = await _repository.GetAllAsync(filter);
            return list;
        }
        #endregion



        #region GetAllInfoPagedAsync
        public async Task<PagedList<ServiceInfoDto>> GetAllInfoPagedAsync(ServiceFilter filter)
        {
            return await _repository.GetAllInfoPagedAsync(filter);
        }
        #endregion


        #region GetAllAsLookup
        public async Task<List<LookupDto>> GetAllAsLookupAsync()
        {
            var filter = new ServiceFilter();
            return await GetAllAsLookupAsync(filter);
        }
        public async Task<List<LookupDto>> GetAllAsLookupAsync(int? portalId = null, int? serviceTypeId = null)
        {
            var filter = new ServiceFilter
            {
                PortalId = portalId,
                ServiceTypeId = serviceTypeId
            };
            return await GetAllAsLookupAsync(filter);
        }
        public async Task<List<LookupDto>> GetAllAsLookupAsync(ServiceFilter filter)
        {
            var list = await GetAllAsync(filter);
            return list.Select(e => new LookupDto
            {
                Id = e.ServiceId,
                Text = e.Name
            }).ToList();
        }
        #endregion


    }
}
