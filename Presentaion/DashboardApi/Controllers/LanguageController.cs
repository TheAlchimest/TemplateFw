﻿using Microsoft.AspNetCore.Mvc;
using TemplateFw.Application.Services;
using TemplateFw.DashboardApi.Controllers.Base;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Domain.GenericResponse;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Domain.Models;

namespace TemplateFw.DashboardApi.Controllers
{

    // [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LanguageController : ApiControllerBase<LanguageController>
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILogger<LanguageController> logger, ILanguageService LanguageService)
            : base(logger)
        {
            languageService = LanguageService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(LanguageDto dto)
        {
            return await ApiResponse(() => languageService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(LanguageDto dto)
        {
             return await ApiResponse(() => languageService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<LanguageDto>> GetById(int id)
        {
            return await GenericApiResponse(() => languageService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<LanguageInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => languageService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<LanguageInfoDto>>> GetAll(LanguageFilter filter)
        {
            return await GenericApiResponse(() => languageService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<LanguageInfoDto>>> GetPagedList(LanguageFilter filter)
        {
            return await GenericApiResponse(() => languageService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => languageService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup()
        {
            return await GenericApiResponse(() => languageService.GetLookupAsync(), OperationTypes.GetList);
        }
        
    }
}
