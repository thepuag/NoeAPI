using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Noe.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        
        public virtual async Task<IEnumerable<T>> GetByColumnStringAsync(string columnName, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, columnName);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
            
            return await _dbSet.Where(lambda).ToListAsync();
        }
        
        public virtual async Task<IEnumerable<T>> GetByColumnIntAsync(string columnName, int value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, columnName);
            var constant = Expression.Constant(value);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
            
            return await _dbSet.Where(lambda).ToListAsync();
        }
        
        public virtual async Task<T> CreateAsync(T entity)
        {
            // Establecer fecha de creación si la entidad la tiene
            if (entity.GetType().GetProperty("FechaCreacion") != null)
            {
                entity.GetType().GetProperty("FechaCreacion")?.SetValue(entity, DateTime.UtcNow);
            }
            
            if (entity.GetType().GetProperty("FechaActualizacion") != null)
            {
                entity.GetType().GetProperty("FechaActualizacion")?.SetValue(entity, DateTime.UtcNow);
            }
            
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public virtual async Task<T> UpdateAsync(T entity)
        {
            // Establecer fecha de actualización si la entidad la tiene
            if (entity.GetType().GetProperty("FechaActualizacion") != null)
            {
                entity.GetType().GetProperty("FechaActualizacion")?.SetValue(entity, DateTime.UtcNow);
            }
            
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        
        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}