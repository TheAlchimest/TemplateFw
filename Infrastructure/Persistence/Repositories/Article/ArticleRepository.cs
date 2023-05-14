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
    public class ArticleRepository : IArticleRepository
    {
        readonly IDbHelper dbHelper;
        public ArticleRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ArticleDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.ArticleId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var articleId = plist.AddOutputParameterInteger("ArticleId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Article_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ArticleDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Article_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ArticleId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Article_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ArticleId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Article_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ArticleInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ArticleId = id;
            ArticleInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ArticleInfoDto>("[dbo].[Article_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ArticleInfoDto>> GetAllAsync(ArticleFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ArticleInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ArticleInfoDto>("[dbo].[Article_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ArticleInfoDto>> GetAllInfoPagedAsync(ArticleFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ArticleInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ArticleInfoDto>("[dbo].[Article_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ArticleInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ArticleDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ArticleId = id;
            ArticleDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ArticleDto>("[dbo].[Article_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
