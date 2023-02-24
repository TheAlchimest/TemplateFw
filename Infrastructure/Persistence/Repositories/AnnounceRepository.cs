using Microsoft.EntityFrameworkCore;
using TemplateFw.Persistence.IRepositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using TemplateFw.Dtos.Announces;
using TemplateFw.Persistence.Extensions;
using TemplateFw.Shared.Dtos.Collections;
using Microsoft.Extensions.Configuration;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Utilities.Helpers;
using TemplateFw.Shared.Helpers;
using TemplateFw.Persistence.Persistent.Db;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using Serilog;

namespace TemplateFw.Persistence.Repositories
{
    public class AnnounceRepository : IAnnounceRepository
    {
        readonly TemplateFwDbContext _dbWrite;
        readonly DgReadOnlyDbContext _dbReadOnly;
        readonly DbSet<Announce> _dbSetReadOnly;
        readonly DbSet<Announce> _dbSetWrite;
        readonly DbSet<VwAnnounceDetail> _detailView;
        readonly DbSet<VwAnnounceFullData> _fullDataView;
        readonly DbSet<AnnounceUser> _announceUserWrite;
        readonly string _writeConnectionString = "";

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AnnounceRepository(TemplateFwDbContext dbWrite, DgReadOnlyDbContext dbReadOnly, IConfiguration configuration)
        {
            //get the writting connection string for stords
            _writeConnectionString = configuration.GetSharedModulesWriteConnectionString();
            //read write db context 
            _dbWrite = dbWrite ?? throw new ArgumentNullException(nameof(dbWrite));
            //read only db context 
            _dbReadOnly = dbReadOnly ?? throw new ArgumentNullException(nameof(dbReadOnly));
            //dbSet Write for Create Update Delete operation
            _dbSetWrite = dbWrite.Announces;
            _announceUserWrite = dbWrite.AnnounceUsers;
            //dbSet ReadOnly for select operation
            _dbSetReadOnly = dbReadOnly.Announces;
            //db detail view
            _detailView = dbReadOnly.VwAnnounceDetail;
            //db full data view
            _fullDataView = dbReadOnly.VwAnnounceFullData;
        }
        #region Write Operations

        #region InsertAsync
        public async Task<Announce> InsertAsync(Announce entity)
        {

            await _dbSetWrite.AddAsync(entity);
            await _dbWrite.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(AnnounceRequestDto dto, string user)
        {
            try
            {
                // Create & open a SqlConnection, and dispose of it after we are done
                using (SqlConnection myConnection = new SqlConnection(_writeConnectionString))
                {
                    SqlCommand masterCmd = SqlHelper.CreateSpCommand("[dbo].[Announce_Update]", myConnection);
                    // Set the parameters
                    masterCmd.Parameters.Add(new SqlParameter("@Id", dto.Id));
                    masterCmd.Parameters.Add(new SqlParameter("@PortalId", dto.PortalId));
                    masterCmd.Parameters.Add(new SqlParameter("@LastModifiedBy", (user.Length > 30) ? user.Substring(0, 29) : user));
                    //
                    SqlCommand detailCmd = SqlHelper.CreateSpCommand("[dbo].[AnnounceDetail_Update]", myConnection);
                    myConnection.Open();
                    foreach (var item in dto.AnnounceDetails)
                    {
                        SqlHelper.ClearAndAttachParameters(detailCmd, item);
                        detailCmd.Parameters.Add(new SqlParameter("@AnnounceId", dto.Id));
                        detailCmd.ExecuteNonQuery();
                    }
                    // Execute the command
                    int resultCount = masterCmd.ExecuteNonQuery();
                    myConnection.Close();

                    //return resultCount;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Announce Repository Error");
                throw ex;
            }

        }
        #endregion

        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id, string user)
        {
            SqlParameter idParameter = new SqlParameter("Id", id);
            SqlParameter userParameter = new SqlParameter("@LastModifiedBy", (user.Length > 30) ? user.Substring(0, 29) : user);
            int affectedRows = SqlHelper.ExecuteNonQuery(_writeConnectionString, CommandType.StoredProcedure,
                "[dbo].[Announce_Delete]", idParameter, userParameter);
            return (affectedRows > 0);
        }
        #endregion

        #region ActivateAsync
        public async Task<bool> ActivateAsync(int id, string user)
        {
            SqlParameter idParameter = new SqlParameter("Id", id);
            SqlParameter userParameter = new SqlParameter("@LastModifiedBy", (user.Length > 30) ? user.Substring(0, 29) : user);
            int affectedRows = SqlHelper.ExecuteNonQuery(_writeConnectionString, CommandType.StoredProcedure,
                "[dbo].[Announce_Activate]", idParameter, userParameter);
            return (affectedRows > 0);
        }
        #endregion

        #region DeactivateAsync
        public async Task<bool> DeactivateAsync(int id, string user)
        {
            SqlParameter idParameter = new SqlParameter("Id", id);
            SqlParameter userParameter = new SqlParameter("@LastModifiedBy", (user.Length > 30) ? user.Substring(0, 29) : user);
            int affectedRows = SqlHelper.ExecuteNonQuery(_writeConnectionString, CommandType.StoredProcedure,
                "[dbo].[Announce_Deactivate]", idParameter, userParameter);
            return (affectedRows > 0);
        }
        #endregion

        #region PreventViewAgainAsync
        public async Task<bool> PreventViewAgainAsync(int announceId, Guid userId)
        {
            var announceUser = new AnnounceUser(announceId, userId);
            await _announceUserWrite.AddAsync(announceUser);
            await _dbWrite.SaveChangesAsync();
            return true;
        }
        #endregion

        #endregion

        #region Read Operations
        #region GetByIdAsync
        public async Task<Announce> GetByIdAsync(int id)
        {
            return await _dbSetReadOnly
                .Where(a => a.Id == id)
                .Where(a => a.IsAvailable)
                .Include(a => a.AnnounceDetails).FirstOrDefaultAsync();
        }
        #endregion

        #region FullDataByIdAsync
        public async Task<VwAnnounceFullData> FullDataByIdAsync(int id, EnumLanguage lang)
        {
            return await _fullDataView
                 .Where(a => a.AnnounceId == id)
                 .Where(a => a.IsAvailable)
                 .Where(a => a.LanguageId == (int)lang).FirstOrDefaultAsync();
        }

        #endregion

        #region GetClientPortalAnnounceAsync
        public async Task<VwAnnounceFullData> GetClientPortalAnnounceAsync(int portalId, Guid userId)
        {
            var announceQ = _fullDataView
                 .Where(a => a.IsAvailable)
                 .Where(a => a.IsEnabled)
                 .Where(a => a.LanguageId == LocalizationsManager.GetLanguage());

            announceQ = announceQ.Where(a => a.PortalId == portalId);

            var announce = await announceQ.FirstOrDefaultAsync();
            if (announce != null && userId != Guid.Empty)
            {
                if (_announceUserWrite.Any(a => a.UserId == userId && a.AnnounceId == announce.AnnounceId))
                    return null;
            }
            return announce;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<VwAnnounceFullData>> GetPagedListAsync(AnnounceGridFilter filter)
        {
            int langId = 1;
            var query = _fullDataView.AsNoTracking().Where(a => a.IsDefaultLanguage);
            if (filter != null)
            {
                if (filter.PortalId.HasValue && filter.PortalId.Value > 0)
                {
                        query = query.Where(f => f.PortalId == filter.PortalId.Value);
                }
                if (!string.IsNullOrWhiteSpace(filter.Search))
                {
                    query = query.Where(f => f.Content.Contains(filter.Search));
                }
                if (filter.LanguageId != 0)
                {
                    langId = filter.LanguageId;
                }
            }
            query = query.Where(f => f.LanguageId == filter.LanguageId);
            query = query.Where(f => f.IsAvailable);
            query = query.OrderByDescending(e => e.AnnounceId);
            return await query.ToPagedListAsync<VwAnnounceFullData>(filter);
        }
        #endregion
        #endregion




    }
}
