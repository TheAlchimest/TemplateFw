using TemplateFw.Domain.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllListAsync();

        Task<List<Country>> GetNonSudiListAsync();
    }
}
