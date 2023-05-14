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
using System.Linq;

namespace TemplateFw.Application.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        #region Fields
        private readonly IPaymentRepository _repository;
        #endregion

        #region Constructor
        public PaymentService(IPaymentRepository repository, IMapper mapper, IUserInfoService userInfoService) : base(mapper, userInfoService)
        {
            _repository = repository;
        }
        #endregion

        #region CreateAsync
        public async Task<bool> CreateAsync(PaymentDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.CreatedBy = user;
            return await _repository.CreateAsync(dto);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(PaymentDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.ModifiedBy = user;
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
        public async Task<PaymentDto> GetOneByIdAsync(int id)
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
        public async Task<PaymentInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang)
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
        public async Task<List<PaymentInfoDto>> GetAllAsync(PaymentFilter filter)
        {
            var list = await _repository.GetAllAsync(filter);
            return list;
        }
        #endregion



        #region GetAllInfoPagedAsync
        public async Task<PagedList<PaymentInfoDto>> GetAllInfoPagedAsync(PaymentFilter filter)
        {
            return await _repository.GetAllInfoPagedAsync(filter);
        }
        #endregion

        #region GetLookupAsync
        public async Task<List<LookupDto>> GetLookupAsync(int? subscriptionId = null)
        {
            var filter = new PaymentFilter
            {
                SubscriptionId = subscriptionId
            };
            return await GetAllAsLookupAsync(filter);
        }
        public async Task<List<LookupDto>> GetAllAsLookupAsync(PaymentFilter filter)
        {
            var list = await GetAllAsync(filter);
            return list.Select(e => new LookupDto(e.PaymentId,e.PaymentMethod)).ToList();
        }
        #endregion
    }
}