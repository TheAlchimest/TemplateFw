﻿using Microsoft.Extensions.Configuration;
using TemplateFw.Shared.Helpers.SqlDataHelpers;

namespace TemplateFw.Persistence.Repositories
{
    public class SqlHelperWrite : Adoler.SqlDataHelper
    {
        public SqlHelperWrite(IConfiguration configuration) : base(configuration.GetSharedModulesWriteConnectionString())
        {
        }

    }
}
