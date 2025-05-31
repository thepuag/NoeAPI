using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen>, IAlmacenRepository
    {
        public AlmacenRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public override async Task<IEnumerable<Almacen>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.Producto).ToListAsync();
        }
        
        public override async Task<Almacen?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(a => a.Producto).FirstOrDefaultAsync(a => a.Id == id);
        }
        
        public async Task<IEnumerable<Almacen>> GetByProductoIdAsync(int productoId)
        {
            return await _dbSet.Include(a => a.Producto)
                              .Where(a => a.IdProducto == productoId)
                              .ToListAsync();
        }
        
        public async Task<Almacen?> GetByProductoIdSingleAsync(int productoId)
        {
            return await _dbSet.Include(a => a.Producto)
                              .FirstOrDefaultAsync(a => a.IdProducto == productoId);
        }
    }
}