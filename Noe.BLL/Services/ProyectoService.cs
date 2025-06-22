using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class ProyectoService : BaseService<Proyecto, ProyectoDto, ProyectoCreateDto, ProyectoUpdateDto>, IProyectoService
    {
        private readonly IProyectoRepository _ProyectoRepository;
        
        public ProyectoService(IProyectoRepository ProyectoRepository, IMapper mapper) 
            : base(ProyectoRepository, mapper)
        {
            _ProyectoRepository = ProyectoRepository;
        }        
        
    }
}