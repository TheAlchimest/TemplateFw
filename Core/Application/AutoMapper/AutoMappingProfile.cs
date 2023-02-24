using AutoMapper;
using TemplateFw.Domain.Models;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Dtos.Announces;
using TemplateFw.Dtos.FAQ;

namespace TemplateFw.Application
{
    public class FaqMapping : Profile
    {
        public FaqMapping()
        {
            //request
            CreateMap<FaqDto, Faq>();
            //Response
            //CreateMap<FaqDetail, FaqResponseDetailDto>();
            CreateMap<Faq, FaqDto>();


        }
    }
    public class AnnounceMapping : Profile
    {
        public AnnounceMapping()
        {
            CreateMap<AnnounceDetailRequestDto, AnnounceDetail>();
            CreateMap<AnnounceRequestDto, Announce>();
            CreateMap<VwAnnounceDetail, AnnounceFullDataDto>();
            CreateMap<AnnounceResponseDto, Announce>();
            CreateMap<Announce, AnnounceResponseDto>();
            CreateMap<AnnounceDetail, AnnounceResponseDetailDto>();
        }
    }

}
