using AutoMapper;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Usuario mappings
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            // Producto mappings
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoCreateDto, Producto>();
            CreateMap<ProductoUpdateDto, Producto>();

            // Almacen mappings
            CreateMap<Almacen, AlmacenDto>();
            CreateMap<AlmacenCreateDto, Almacen>();
            CreateMap<AlmacenUpdateDto, Almacen>();

            // Proyecto mappings
            CreateMap<Proyecto, ProyectoDto>();
            CreateMap<ProyectoCreateDto, Proyecto>();
            CreateMap<ProyectoUpdateDto, Proyecto>();

            // Tecnologia mappings
            CreateMap<Tecnologia, TecnologiaDto>();
            CreateMap<TecnologiaCreateDto, Tecnologia>();
            CreateMap<TecnologiaUpdateDto, Tecnologia>();
            
            // ProyectoTecnologia mappings
            CreateMap<ProyectoTecnologia, ProyectoTecnologiaDto>();
            CreateMap<ProyectoTecnologiaCreateDto, ProyectoTecnologia>();
            CreateMap<ProyectoTecnologiaUpdateDto, ProyectoTecnologia>();
        }
    }
}