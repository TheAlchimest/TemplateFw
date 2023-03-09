using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Persistence.Repositories;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;

namespace TemplateFw.Application.Services.FAQ
{
    public class FaqService : BaseService, IFaqService
    {
        #region Fields
        private readonly IFaqRepository _repository;
        #endregion

        #region Constructor
        public FaqService(IFaqRepository repository, IMapper mapper, IUserInfoService userInfoService) : base(mapper, userInfoService)
        {
            _repository = repository;
        }
        #endregion

        #region CreateAsync
        public async Task<bool> CreateAsync(FaqDto model)
        {
            var entity = _mapper.Map<Faq>(model);
            SetCreationData(entity);
            return await _repository.CreateAsync(entity);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(FaqDto dto)
        {
            string user = _userInfoService.GetCurrentUserName();
            dto.LastModifiedBy = user;
            dto.LastModificationDate = DateTime.Now;
            return await _repository.UpdateAsync(dto);
        }
        #endregion

        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            string user = _userInfoService.GetCurrentUserName();
            return await _repository.DeleteAsync(id, user);
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<FaqDto> GetOneByIdAsync(int id)
        {
            var entity = await _repository.GetOneByIdAsync(id);

            if (entity is null)
            {
                throw new BusinessException(ErrorCodes.NotFound);
            }
            var dto = _mapper.Map<FaqDto>(entity);

            return dto;
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang)
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
        public async Task<List<FaqInfoDto>> GetAllAsync(EnumLanguage lang = EnumLanguage.Arabic, int? portalId = null, int? serviceId = null)
        {
            var list = await _repository.GetAllAsync(lang, portalId, serviceId);
            return list;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<FaqInfoDto>> GetAllAsync(FaqGridFilter filter)
        {
            return await _repository.GetAllAsync((EnumLanguage)filter.LanguageId, filter.PortalId, filter.ServiceId);
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<FaqInfoDto>> GetPagedListAsync(FaqGridFilter filter)
        {
            return await _repository.GetPagedListAsync(filter);
        }
        #endregion

        #region GetPageByPageAsync
        public async Task<PagedList<FaqInfoDto>> GetPageByPageAsync(FaqGridFilter filter)
        {
            return await _repository.GetPageByPageAsync(filter);
        }
        #endregion
    }
}
