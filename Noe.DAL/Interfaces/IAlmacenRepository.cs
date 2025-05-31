using Noe.Models.Entities;

namespace Noe.DAL.Interfaces
{
    public interface IAlmacenRepository : IBaseRepository<Almacen>
    {
        Task<IEnumerable<Almacen>> GetByProductoIdAsync(int productoId);
        Task<Almacen?> GetByProductoIdSingleAsync(int productoId);
    }
}