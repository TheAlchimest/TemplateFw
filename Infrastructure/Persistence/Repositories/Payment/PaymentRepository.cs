﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Common;
using TemplateFw.Dtos;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dtos.Collections;
using Adoler.AdoExtension.Extensions;
using TemplateFw.Persistence.IRepositories;

namespace TemplateFw.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly IDbHelper dbHelper;
        public PaymentRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(PaymentDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.PaymentId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var paymentId = plist.AddOutputParameterInteger("PaymentId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Payment_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(PaymentDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Payment_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.PaymentId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Payment_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.PaymentId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Payment_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<PaymentInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.PaymentId = id;
            PaymentInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<PaymentInfoDto>("[dbo].[Payment_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<PaymentInfoDto>> GetAllAsync(PaymentFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<PaymentInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<PaymentInfoDto>("[dbo].[Payment_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<PaymentInfoDto>> GetAllInfoPagedAsync(PaymentFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<PaymentInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<PaymentInfoDto>("[dbo].[Payment_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<PaymentInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<PaymentDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.PaymentId = id;
            PaymentDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<PaymentDto>("[dbo].[Payment_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
