using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TemplateFw.Shared.Dtos.Collections;
using Microsoft.Extensions.Configuration;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Dtos.Identity;
using TemplateFw.Shared.Helpers.SqlDataHelpers;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Dtos.Dtos.Common;
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
