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
    public class LanguageRepository : ILanguageRepository
    {
        readonly IDbHelper dbHelper;
        public LanguageRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(LanguageDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.LanguageId, e => e.CreationDate, e => e.LastModifiedBy, e => e.LastModificationDate, e => e.IsAvailable);
            var languageId = plist.AddOutputParameterInteger("LanguageId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Language_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(LanguageDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.LastModificationDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Language_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = id;
            parameters.LastModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Language_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Language_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<LanguageInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.LanguageId = id;
            LanguageInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<LanguageInfoDto>("[dbo].[Language_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<LanguageInfoDto>> GetAllAsync(LanguageFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<LanguageInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<LanguageInfoDto>("[dbo].[Language_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<LanguageInfoDto>> GetAllInfoPagedAsync(LanguageFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<LanguageInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<LanguageInfoDto>("[dbo].[Language_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<LanguageInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<LanguageDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = id;
            LanguageDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<LanguageDto>("[dbo].[Language_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
