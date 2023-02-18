using Driver.Application.DTO;
using AutoMapper;
using Driver.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DriverEntity, DriverDTO>().ReverseMap();
            CreateMap<DriverEntity, DriverForCreationDto>().ReverseMap();
            CreateMap<DriverEntity, DriverForUpdateDto>().ReverseMap();
        }
    }
}
