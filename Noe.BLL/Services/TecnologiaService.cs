using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class TecnologiaService : BaseService<Tecnologia, TecnologiaDto, TecnologiaCreateDto, TecnologiaUpdateDto>, ITecnologiaService
    {
        private readonly ITecnologiaRepository _TecnologiaRepository;
        
        public TecnologiaService(ITecnologiaRepository TecnologiaRepository, IMapper mapper) 
            : base(TecnologiaRepository, mapper)
        {
            _TecnologiaRepository = TecnologiaRepository;
        }        
        
    }
}