using Noe.Models.DTOs;

namespace Noe.BLL.Interfaces
{
    public interface IAlmacenService : IBaseService<AlmacenDto, AlmacenCreateDto, AlmacenUpdateDto>
    {
        Task<IEnumerable<AlmacenDto>> GetByProductoIdAsync(int productoId);
        Task<AlmacenDto?> GetByProductoIdSingleAsync(int productoId);
    }
}