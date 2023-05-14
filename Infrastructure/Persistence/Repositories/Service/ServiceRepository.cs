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
    public class ServiceRepository : IServiceRepository
    {
        readonly IDbHelper dbHelper;
        public ServiceRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ServiceDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.ServiceId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var serviceId = plist.AddOutputParameterInteger("ServiceId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Service_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ServiceDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Service_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Service_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Service_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ServiceInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ServiceId = id;
            ServiceInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ServiceInfoDto>("[dbo].[Service_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ServiceInfoDto>> GetAllAsync(ServiceFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ServiceInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ServiceInfoDto>("[dbo].[Service_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ServiceInfoDto>> GetAllInfoPagedAsync(ServiceFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ServiceInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ServiceInfoDto>("[dbo].[Service_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ServiceInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ServiceDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceId = id;
            ServiceDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ServiceDto>("[dbo].[Service_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
