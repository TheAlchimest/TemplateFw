using AutoMapper;
using TemplateFw.Domain.Models.Countries;
using TemplateFw.Dtos.Dtos.Common;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateFw.Application.Services.Countries
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly ICountryRepository _repository;
        public CountryService(ICountryRepository repository, IMapper mapper, IUserInfoService userInfoService)
            : base(mapper, userInfoService)
        {
            _repository = repository;
        }

        public async Task<List<LookupDto>> GetAllListAsync(EnumLanguage language)
        {
            var countries = await _repository.GetAllListAsync();
            return countries.Select(a => new LookupDto()
            {
                Id = a.Id,
                Text = (language == EnumLanguage.English) ? a.EnName : a.ArName
            }).OrderBy(a => a.Text).ToList();
        }

        public async Task<List<LookupDto>> GetNonSaudiListAsync(EnumLanguage language)
        {
            var countries = await _repository.GetNonSudiListAsync();
            return countries.Select(a => new LookupDto()
            {
                Id = a.Id,
                Text = (language == EnumLanguage.English) ? a.EnName : a.ArName
            }).OrderBy(a => a.Text).ToList();
        }
    }
}
