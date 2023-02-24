using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using TemplateFw.Domain.Models;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Persistence.Persistent.Db;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using Microsoft.Extensions.Configuration;

namespace TemplateFw.Persistence.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        readonly DgReadOnlyDbContext _dbReadOnly;
        readonly DbSet<Language> _dbSetReadOnly;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public LanguageRepository(DgReadOnlyDbContext dbReadOnly)
        {
            //read only db context 
            _dbReadOnly = dbReadOnly ?? throw new ArgumentNullException(nameof(dbReadOnly));
            //dbSet ReadOnly for select operation
            _dbSetReadOnly = dbReadOnly.Languages;
        }

        #region Read Operations

        #region GetAllLanguagesAsync
        public async Task<List<LookupDto>> GetAllLanguagesAsync()
        {
            return await _dbSetReadOnly.Select(e => new LookupDto
            {
                Id = e.Id,
                Text = e.Name
            }).ToListAsync();
        }
        #endregion

        #endregion

    }
}
