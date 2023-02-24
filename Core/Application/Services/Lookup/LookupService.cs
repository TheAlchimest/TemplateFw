using AutoMapper;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Dtos.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFw.Shared.Application.Exceptions;
using TemplateFw.Shared.Domain.Enums;
using TemplateFw.Shared.Dto;
using TemplateFw.Shared.Helpers;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using TemplateFw.Resources;
using TemplateFw.Shared.Dtos.Identity;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Dtos.Dtos.Common;

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
