using Adoler;
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

namespace TemplateFw.Persistence.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        readonly IDbHelper dbHelper;
        readonly DbSet<Faq> dbSetReadOnly;
        readonly DbSet<Faq> dbSetWrite;
        readonly DbSet<VwFaq> _fullDataView;
        readonly string _writeConnectionString = "";
        readonly string _readConnectionString = "";

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public FaqRepository(IDbHelper dbHelper)
        {
            //get the writting connection string for stords
            this.dbHelper = dbHelper;
            //dbSet Write for Create Update Delete operation
            dbSetWrite = dbHelper.dbWrite.Faqs;
            //dbSet ReadOnly for select operation
            dbSetReadOnly = dbHelper.dbReadOnly.Faqs;
            //db detail view
            _fullDataView = dbHelper.dbReadOnly.VwFaq;

        }

        #region InsertAsync
        public async Task<bool> CreateAsync(FaqDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.FaqId, e => e.CreatedBy, e => e.LastModifiedBy, e => e.LastModificationDate, e => e.IsAvailable);
            var faqID = plist.AddOutputParameterInteger("FaqId");
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(FaqDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.LastModificationDate, e => e.IsAvailable);
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.FaqId = id;
            parameters.LastModifiedBy = user;
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.FaqId = id;
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<FaqInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = lang;
            parameters.FaqId = id;
            FaqInfoDto item = dbHelper.SqlHelperRead.GetOne<FaqInfoDto>("[dbo].[Faq_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<FaqInfoDto>> GetAllAsync(FaqFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<FaqInfoDto> list = dbHelper.SqlHelperRead.GetList<FaqInfoDto>("[dbo].[Faq_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<FaqInfoDto>> GetAllInfoPagedAsync(FaqFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<FaqInfoDto> list = dbHelper.SqlHelperRead.GetList<FaqInfoDto>("[dbo].[Faq_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<FaqInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<FaqDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.FaqId = id;
            FaqDto item = dbHelper.SqlHelperRead.GetOne<FaqDto>("[dbo].[Faq_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
