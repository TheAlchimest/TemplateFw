using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFw.Domain.Models.Countries;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Persistence.Persistent.Db;

namespace TemplateFw.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        readonly DgReadOnlyDbContext _dbReadOnly;
        readonly DbSet<Country> _dbSetReadOnly;

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CountryRepository(DgReadOnlyDbContext dbReadOnly)
        {
            //read only db context 
            _dbReadOnly = dbReadOnly ?? throw new ArgumentNullException(nameof(dbReadOnly));
            //dbSet ReadOnly for select operation
            _dbSetReadOnly = dbReadOnly.Countries;

        }

        #region Read Operations

        #region GetAllListAsync
        public Task<List<Country>> GetAllListAsync()
        {
            return _dbSetReadOnly.ToListAsync();
        }
        #endregion

        #region GetNonSudiListAsync
        public Task<List<Country>> GetNonSudiListAsync()
        {
            return _dbSetReadOnly.Where(a => a.Id != 194).ToListAsync();
        }
        #endregion


        #endregion

    }
}
