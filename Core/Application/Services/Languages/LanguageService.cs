using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Persistence.IRepositories;

namespace TemplateFw.Application.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        #region GetAllLanguagesAsync
        public Task<List<LookupDto>> GetAllLanguagesAsync()
        {
            return _languageRepository.GetAllLanguagesAsync();
        }
        #endregion
    }
}
