using System;
using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EnergyUsage, EnergyDto>()
                .ForMember(dest =>dest.DateEntered, opt=>opt.MapFrom(src =>src.InputDate))
                .ForMember(dest=>dest.PriceAfterDiscount, opt =>opt.MapFrom(src => ((src.InputDate.DayOfWeek==DayOfWeek.Saturday)
                 ||(src.InputDate.DayOfWeek==DayOfWeek.Sunday))? src.Price*90/100 : src.Price ));
        }
    }
}