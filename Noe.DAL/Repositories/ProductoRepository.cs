using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Producto>> GetActiveProductsAsync()
        {
            return await _dbSet.Where(p => p.Activo).ToListAsync();
        }
    }
}