using Noe.Models.DTOs;

namespace Noe.BLL.Interfaces
{
    public interface IProductoService : IBaseService<ProductoDto, ProductoCreateDto, ProductoUpdateDto>
    {
        Task<IEnumerable<ProductoDto>> GetActiveProductsAsync();
    }
}