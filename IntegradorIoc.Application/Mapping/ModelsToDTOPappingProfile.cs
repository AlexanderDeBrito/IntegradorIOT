using AutoMapper;
using IntegradorIot.Models;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Models;

namespace IntegradorIoc.Application.Mapping
{
    public class ModelsToDTOPappingProfile : Profile
    {
        public ModelsToDTOPappingProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<CommandDescriptionDto, CommandDescription>().ReverseMap()
                 .ForMember(dest => dest.DeviceDto, opt => opt.MapFrom(x => x.Device));
            CreateMap<CommandDto, Commands>().ReverseMap()
                .ForMember(dest => dest.commandDescriptionDto, opt => opt.MapFrom(x => x.CommandDescription));
            CreateMap<ParameterDto, Parameter>().ReverseMap()
                .ForMember(dest => dest.CommandDto, opt => opt.MapFrom(x=>x.Command));
   
            CreateMap<Usuario,UsuarioDto>().ReverseMap();
        }
    }

}
