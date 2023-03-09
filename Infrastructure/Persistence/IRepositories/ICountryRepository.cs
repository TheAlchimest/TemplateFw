using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Domain.Models.Countries;

namespace TemplateFw.Persistence.IRepositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllListAsync();

        Task<List<Country>> GetNonSudiListAsync();
    }
}
