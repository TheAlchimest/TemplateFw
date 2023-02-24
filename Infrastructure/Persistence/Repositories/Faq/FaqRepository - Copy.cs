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

namespace TemplateFw.Persistence.Repositories
{
    public class SqlHelperWrite : Adoler.SqlDataHelper
    {
        public SqlHelperWrite(IConfiguration configuration) : base(configuration.GetSharedModulesWriteConnectionString())
        {
        }

    }
    public class SqlHelperRead : Adoler.SqlDataHelper
    {
        public SqlHelperRead(IConfiguration configuration) : base(configuration.GetSharedModulesReadOnlyConnectionString())
        {
        }

    }
    public class DbHelper : IDbHelper
    {
        public TemplateFwDbContext dbWrite { get; }
        public DgReadOnlyDbContext dbReadOnly { get; }
        public SqlHelperWrite SqlHelperWrite { get; }
        public SqlHelperRead SqlHelperRead { get; }
        public string WriteConnectionString { get; }
        public string ReadConnectionString { get; }

        public DbHelper(TemplateFwDbContext dbWrite, DgReadOnlyDbContext dbReadOnly, SqlHelperWrite dbHelperWrite, SqlHelperRead dbHelperRead, IConfiguration configuration)
        {
            this.dbWrite = dbWrite;
            this.dbReadOnly = dbReadOnly;
            SqlHelperWrite = dbHelperWrite;
            SqlHelperRead = dbHelperRead;
            WriteConnectionString = configuration.GetSharedModulesWriteConnectionString();
            ReadConnectionString = configuration.GetSharedModulesReadOnlyConnectionString();
        }

    }
}
