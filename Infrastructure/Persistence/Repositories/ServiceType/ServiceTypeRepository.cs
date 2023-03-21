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
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        readonly IDbHelper dbHelper;
        public ServiceTypeRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ServiceTypeDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.ServiceTypeId, e => e.CreationDate, e => e.LastModifiedBy, e => e.LastModificationDate, e => e.IsAvailable);
            var serviceTypeId = plist.AddOutputParameterInteger("ServiceTypeId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ServiceType_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ServiceTypeDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.LastModificationDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ServiceType_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceTypeId = id;
            parameters.LastModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ServiceType_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceTypeId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ServiceType_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ServiceTypeInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ServiceTypeId = id;
            ServiceTypeInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ServiceTypeInfoDto>("[dbo].[ServiceType_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ServiceTypeInfoDto>> GetAllAsync(ServiceTypeFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ServiceTypeInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ServiceTypeInfoDto>("[dbo].[ServiceType_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ServiceTypeInfoDto>> GetAllInfoPagedAsync(ServiceTypeFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ServiceTypeInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ServiceTypeInfoDto>("[dbo].[ServiceType_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ServiceTypeInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ServiceTypeDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ServiceTypeId = id;
            ServiceTypeDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ServiceTypeDto>("[dbo].[ServiceType_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
