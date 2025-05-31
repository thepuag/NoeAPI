using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class AlmacenService : BaseService<Almacen, AlmacenDto, AlmacenCreateDto, AlmacenUpdateDto>, IAlmacenService
    {
        private readonly IAlmacenRepository _almacenRepository;
        
        public AlmacenService(IAlmacenRepository almacenRepository, IMapper mapper) 
            : base(almacenRepository, mapper)
        {
            _almacenRepository = almacenRepository;
        }
        
        public async Task<IEnumerable<AlmacenDto>> GetByProductoIdAsync(int productoId)
        {
            var almacenes = await _almacenRepository.GetByProductoIdAsync(productoId);
            return _mapper.Map<IEnumerable<AlmacenDto>>(almacenes);
        }
        
        public async Task<AlmacenDto?> GetByProductoIdSingleAsync(int productoId)
        {
            var almacen = await _almacenRepository.GetByProductoIdSingleAsync(productoId);
            return almacen == null ? null : _mapper.Map<AlmacenDto>(almacen);
        }
    }
}