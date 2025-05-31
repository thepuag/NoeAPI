using Noe.Models.Entities;

namespace Noe.DAL.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetActiveProductsAsync();
    }
}