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
    public class PaymentController : ApiControllerBase<PaymentController>
    {
        private readonly IPaymentService paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService PaymentService)
            : base(logger)
        {
            paymentService = PaymentService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("create")]
        public async Task<ApiResponse> Create(PaymentDto dto)
        {
            return await ApiResponse(() => paymentService.CreateAsync(dto), OperationTypes.Add);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("update")]
        public async Task<ApiResponse> Update(PaymentDto dto)
        {
             return await ApiResponse(() => paymentService.UpdateAsync(dto), OperationTypes.Update);
        }
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getone/{id}")]
        public async Task<GenericApiResponse<PaymentDto>> GetById(int id)
        {
            return await GenericApiResponse(() => paymentService.GetOneByIdAsync(id), OperationTypes.GetOne);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("info/{id}")]
        public async Task<GenericApiResponse<PaymentInfoDto>> GetInfoById(int id)
        {
            return await GenericApiResponse(() => paymentService.GetInfoByIdAsync(id, CurrentLanguage), OperationTypes.GetOne);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getall")]
        public async Task<GenericApiResponse<List<PaymentInfoDto>>> GetAll(PaymentFilter filter)
        {
            return await GenericApiResponse(() => paymentService.GetAllAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("get-paged")]
        public async Task<GenericApiResponse<PagedList<PaymentInfoDto>>> GetPagedList(PaymentFilter filter)
        {
            return await GenericApiResponse(() => paymentService.GetAllInfoPagedAsync(filter), OperationTypes.GetList);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("delete/{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            return await ApiResponse(() => paymentService.DeleteVirtuallyAsync(id), OperationTypes.Delete);
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("lookup")]
        public async Task<GenericApiResponse<List<LookupDto>>> GetLookup(int? subscriptionId = null)
        {
            return await GenericApiResponse(() => paymentService.GetLookupAsync(subscriptionId), OperationTypes.GetList);
        }
        
    }
}
