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

        }
    }
}
