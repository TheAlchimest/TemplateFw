using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateFw.Shared.Domain.Enums;

namespace TemplateFw.Shared.Helpers.SqlDataHelpers
{
    public static class ConfigurationExtensions
    {
        public static string GetSharedModulesWriteConnectionString(this IConfiguration configuration)
        {
            string writeConnectionString = configuration.GetConnectionString("DashboardWriteConnection");
            bool? disableConnectionEncryption = configuration.GetValue<bool?>("DisableConnectionEncryption");
            if (disableConnectionEncryption != true)
            {
                writeConnectionString = StringCipher.Decrypt(writeConnectionString);
            }
            return writeConnectionString;
        }
        public static string GetSharedModulesReadOnlyConnectionString(this IConfiguration configuration)
        {
            string writeConnectionString = configuration.GetConnectionString("DashboardReadOnlyConnection");
            bool? disableConnectionEncryption = configuration.GetValue<bool?>("DisableConnectionEncryption");
            if (disableConnectionEncryption != true)
            {
                writeConnectionString = StringCipher.Decrypt(writeConnectionString);
            }
            return writeConnectionString;
        }
        
    }
    
}
