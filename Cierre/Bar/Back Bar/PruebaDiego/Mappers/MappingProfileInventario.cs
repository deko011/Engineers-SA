using AutoMapper;
using PruebaDiego.Models.DataTransferObjects;
using PruebaDiego.Models.Input;

namespace PruebaDiego.Mappers
{
    public class MappingProfileInventario : Profile
    {
        public MappingProfileInventario()
        {

            CreateMap<InventarioDto, Inventario>()


              .ForMember(dest => dest.Codigo,
                         opt => opt.MapFrom(src => src.codigo))
              .ForMember(dest => dest.Nombre,
                         opt => opt.MapFrom(src => src.nombre))
              .ForMember(dest => dest.Producto,
                         opt => opt.MapFrom(src => src.producto))
              .ForMember(dest => dest.Cantidad,
                         opt => opt.MapFrom(src => src.cantidad))
              .ForMember(dest => dest.Fecha_Ingreso,
                         opt => opt.MapFrom(src => src.fecha_ingreso))
              .ForMember(dest => dest.Fecha_Salida,
                         opt => opt.MapFrom(src => src.fecha_salida))
              .ForMember(dest => dest.Sedes,
                         opt => opt.MapFrom(src => src.sedes));


        }
    }
}
