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
    public class AuthorRepository : IAuthorRepository
    {
        readonly IDbHelper dbHelper;
        public AuthorRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(AuthorDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.AuthorId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var authorId = plist.AddOutputParameterInteger("AuthorId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Author_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(AuthorDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Author_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.AuthorId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Author_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.AuthorId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Author_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<AuthorInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.AuthorId = id;
            AuthorInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<AuthorInfoDto>("[dbo].[Author_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<AuthorInfoDto>> GetAllAsync(AuthorFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<AuthorInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<AuthorInfoDto>("[dbo].[Author_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<AuthorInfoDto>> GetAllInfoPagedAsync(AuthorFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<AuthorInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<AuthorInfoDto>("[dbo].[Author_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<AuthorInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<AuthorDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.AuthorId = id;
            AuthorDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<AuthorDto>("[dbo].[Author_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
