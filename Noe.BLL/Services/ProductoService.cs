using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class ProductoService : BaseService<Producto, ProductoDto, ProductoCreateDto, ProductoUpdateDto>, IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        
        public ProductoService(IProductoRepository productoRepository, IMapper mapper) 
            : base(productoRepository, mapper)
        {
            _productoRepository = productoRepository;
        }
        
        public async Task<IEnumerable<ProductoDto>> GetActiveProductsAsync()
        {
            var productos = await _productoRepository.GetActiveProductsAsync();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }
    }
}