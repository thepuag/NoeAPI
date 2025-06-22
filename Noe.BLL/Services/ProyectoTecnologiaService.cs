using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class ProyectoTecnologiaService : BaseService<ProyectoTecnologia, ProyectoTecnologiaDto, ProyectoTecnologiaCreateDto, ProyectoTecnologiaUpdateDto>, IProyectoTecnologiaService
    {
        private readonly IProyectoTecnologiaRepository _ProyectoTecnologiaRepository;
        
        public ProyectoTecnologiaService(IProyectoTecnologiaRepository ProyectoTecnologiaRepository, IMapper mapper) 
            : base(ProyectoTecnologiaRepository, mapper)
        {
            _ProyectoTecnologiaRepository = ProyectoTecnologiaRepository;
        }        
        
    }
}