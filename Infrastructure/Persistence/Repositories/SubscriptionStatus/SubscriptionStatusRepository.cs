using Microsoft.Data.SqlClient;
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
    public class SubscriptionStatusRepository : ISubscriptionStatusRepository
    {
        readonly IDbHelper dbHelper;
        public SubscriptionStatusRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(SubscriptionStatusDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.SubscriptionStatusId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var subscriptionStatusId = plist.AddOutputParameterInteger("SubscriptionStatusId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[SubscriptionStatus_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(SubscriptionStatusDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[SubscriptionStatus_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.SubscriptionStatusId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[SubscriptionStatus_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.SubscriptionStatusId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[SubscriptionStatus_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<SubscriptionStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.SubscriptionStatusId = id;
            SubscriptionStatusInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<SubscriptionStatusInfoDto>("[dbo].[SubscriptionStatus_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<SubscriptionStatusInfoDto>> GetAllAsync(SubscriptionStatusFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<SubscriptionStatusInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<SubscriptionStatusInfoDto>("[dbo].[SubscriptionStatus_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<SubscriptionStatusInfoDto>> GetAllInfoPagedAsync(SubscriptionStatusFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<SubscriptionStatusInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<SubscriptionStatusInfoDto>("[dbo].[SubscriptionStatus_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<SubscriptionStatusInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<SubscriptionStatusDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.SubscriptionStatusId = id;
            SubscriptionStatusDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<SubscriptionStatusDto>("[dbo].[SubscriptionStatus_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
