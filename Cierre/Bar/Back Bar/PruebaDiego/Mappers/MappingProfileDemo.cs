using AutoMapper;
using PruebaDiego.Models.DataTransferObjects;
using PruebaDiego.Models.Input;

namespace PruebaDiego.Mappers
{
    public class MappingProfileDemo : Profile
    {
        public MappingProfileDemo()
        {

            CreateMap<UsuariosDto, Usuario>()


              .ForMember(dest => dest.Usuarios,
                         opt => opt.MapFrom(src => src.usuario))
              .ForMember(dest => dest.Contraseña,
                         opt => opt.MapFrom(src => src.contraseña));
            



        }
    }
}