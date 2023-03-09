using Microsoft.Extensions.Configuration;
using System;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Persistence.Persistent.Db;

namespace TemplateFw.Persistence.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        readonly DgReadOnlyDbContext _dbReadOnly;

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public LookupRepository(TemplateFwDbContext dbWrite, DgReadOnlyDbContext dbReadOnly, IConfiguration configuration)
        {
            //read only db context 
            _dbReadOnly = dbReadOnly ?? throw new ArgumentNullException(nameof(dbReadOnly));
        }



    }
}
