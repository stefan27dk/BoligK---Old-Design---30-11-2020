using AutoMapper;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.ApplicationService.Mapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AnsøgningDto, Ansøgning>().ReverseMap();
            CreateMap<AnsøgerDto, Ansøger>().ReverseMap();
            CreateMap<IKriterieDto, IKriterie>().IncludeAllDerived().ReverseMap();
            CreateMap<IValidateableKriterieDto, IValidateableKriterie>().ReverseMap();
            CreateMap<LejemålsTypeKriterieDto, LejemålsTypeKriterie>().ReverseMap();
            CreateMap<LokationKriterieDto, LokationKriterie>().ReverseMap();
            CreateMap<TilladtDyrKriterieDto,TilladtDyrKriterie>().ReverseMap();
            CreateMap<RangeKriterieDto,RangeKriterie>().IncludeAllDerived().ReverseMap();
            CreateMap<KvmKriterieDto,KvmKriterie>().ReverseMap();
            CreateMap<PrisKriterieDto,PrisKriterie>().ReverseMap();
            CreateMap<VærelsesKriterieDto,VærelsesKriterie>().ReverseMap();
        }
    }
}
