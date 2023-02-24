using Microsoft.EntityFrameworkCore;
using TemplateFw.Persistence.IRepositories;
using System;
using System.Threading.Tasks;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using Microsoft.Extensions.Configuration;
using TemplateFw.Persistence.Persistent.Db;
using TemplateFw.Domain.Models;

namespace TemplateFw.Persistence.Repositories
{
    public class ActionLogRepository : IActionLogRepository
    {
        readonly TemplateFwDbContext _dbWrite;
        readonly DgReadOnlyDbContext _dbReadOnly;
        readonly DbSet<ActionLog> _dbSetReadOnly;
        readonly DbSet<ActionLog> _dbSetWrite;
        readonly string _writeConnectionString = "";

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ActionLogRepository(TemplateFwDbContext dbWrite, DgReadOnlyDbContext dbReadOnly, IConfiguration configuration)
        {
            //get the writting connection string for stords
            _writeConnectionString = configuration.GetSharedModulesWriteConnectionString();
            //read write db context 
            _dbWrite = dbWrite ?? throw new ArgumentNullException(nameof(dbWrite));
            //read only db context 
            _dbReadOnly = dbReadOnly ?? throw new ArgumentNullException(nameof(dbReadOnly));
            //dbSet Write for Create Update Delete operation
            _dbSetWrite = dbWrite.ActionLogs;
            //dbSet ReadOnly for select operation
            _dbSetReadOnly = dbReadOnly.ActionLogs;

        }

        #region InsertAsync
        public async Task<ActionLog> InsertAsync(ActionLog entity)
        {
            await _dbSetWrite.AddAsync(entity);
            await _dbWrite.SaveChangesAsync();
            return entity;
        }
        #endregion
    }
}
