using TemplateFw.Persistence.IRepositories;

namespace TemplateFw.Application.Services.Lookup
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _repository;


        public LookupService(ILookupRepository repository)
        {
            _repository = repository;
        }
    }
}
