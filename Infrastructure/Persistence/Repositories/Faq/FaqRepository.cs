using Microsoft.EntityFrameworkCore;
using TemplateFw.Domain.Models;
using TemplateFw.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using TemplateFw.Dtos.FAQ;
using TemplateFw.Shared.Dtos.Collections;
using TemplateFw.Dtos.Common;
using TemplateFw.Persistence.Extensions;
using Microsoft.Extensions.Configuration;
using TemplateFw.Utilities.Helpers;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Helpers;
using TemplateFw.Persistence.Persistent.Db;

using Adoler;
using System.Dynamic;

namespace TemplateFw.Persistence.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        readonly IDbHelper dbHelper;
        readonly DbSet<Faq> dbSetReadOnly;
        readonly DbSet<Faq> dbSetWrite;
        readonly DbSet<VwFaqFullData> _fullDataView;
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
            _fullDataView = dbHelper.dbReadOnly.VwFaqFullData;

        }
        #region Write Operations

        #region InsertAsync
        public async Task<bool> CreateAsync(Faq entity)
        {
            await dbSetWrite.AddAsync(entity);
            int affectedRows = await dbHelper.dbWrite.SaveChangesAsync();
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(FaqDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.IsAvailable);
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.FaqId = id;
            parameters.LastModifiedBy = user;
            int affectedRows = dbHelper.SqlHelperWrite.ExecuteNonQuery("[dbo].[Faq_Delete]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetAllAsync
        public async Task<List<FaqInfoDto>> GetAllAsync(EnumLanguage lang = EnumLanguage.Arabic, int? portalId = null, int? serviceId = null)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LangId = (int)lang;
            parameters.PortalId = portalId;
            parameters.ServiceId = serviceId;
            List<FaqInfoDto> list = dbHelper.SqlHelperRead.GetList<FaqInfoDto>("[dbo].[Faq_SelectAll]", parameters);
            return list;
        }
        #endregion
        #region GetAllAsync
        public async Task<FaqInfoDto> GetInfoByIdAsync(int id , EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LangId = lang;
            parameters.FaqId = id;
            FaqInfoDto item = dbHelper.SqlHelperRead.GetOne<FaqInfoDto>("[dbo].[Faq_SelectOne]", parameters);
            return item;
        }
        #endregion

        #endregion
        #region Read Operations

        #region GetByIdAsync
        public async Task<Faq> GetOneByIdAsync(int id)
        {
            return await dbSetReadOnly
                .Where(a => a.FaqId == id)
                .Where(a => a.IsAvailable)
                .FirstOrDefaultAsync();
        }

        #endregion


        #region GetPagedListAsync
        public async Task<PagedList<FaqInfoDto>> GetPagedListAsync(FaqGridFilter filter)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LangId = 1;
            List<FaqInfoDto> list = dbHelper.SqlHelperRead.GetList<FaqInfoDto>("[dbo].[Faq_SelectAll]", parameters);
            var pagedList = new PagedList<FaqInfoDto>(list, 1, 10, 100);
            return pagedList;
        }

        #endregion
        /*
        #region GetPagedListAsync
        public async Task<PagedList<VwFaqFullData>> GetPagedListAsync(FaqGridFilter filter)
        {
            int langId = 1;
            var query = _fullDataView.AsNoTracking();
            if (filter != null)
            {
                if (filter.PortalId.HasValue && filter.PortalId.Value > 0)
                {
                    query = query.Where(f => f.PortalId == filter.PortalId.Value);
                }
                if (filter.ServiceId.HasValue && filter.ServiceId.Value > 0)
                {
                    query = query.Where(f => f.ServiceId == filter.ServiceId);
                }
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    query = query.Where(f => f.QuestionAr.Contains(filter.Search) || f.QuestionEn.Contains(filter.Search));
                }
                langId = filter.LanguageId;
            }
            //LanguageId
            // query = query.Where(f => f.LanguageId == langId);
            query = query.Where(f => f.IsAvailable);
            //order by the latest items first
            query = query.OrderByDescending(e => e.FaqId);
            //ToPagedListAsync
            return await query.ToPagedListAsync<VwFaqFullData>(filter);
        }

        #endregion
        */
        

        #endregion











    }
}
