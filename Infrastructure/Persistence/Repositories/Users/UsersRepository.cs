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
    public class UsersRepository : IUsersRepository
    {
        readonly IDbHelper dbHelper;
        public UsersRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(UsersDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.UserId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var userId = plist.AddOutputParameterInteger("UserId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Users_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(UsersDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Users_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.UserId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Users_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.UserId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[Users_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<UsersInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.UserId = id;
            UsersInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<UsersInfoDto>("[dbo].[Users_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<UsersInfoDto>> GetAllAsync(UsersFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<UsersInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<UsersInfoDto>("[dbo].[Users_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<UsersInfoDto>> GetAllInfoPagedAsync(UsersFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<UsersInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<UsersInfoDto>("[dbo].[Users_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<UsersInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<UsersDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.UserId = id;
            UsersDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<UsersDto>("[dbo].[Users_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
