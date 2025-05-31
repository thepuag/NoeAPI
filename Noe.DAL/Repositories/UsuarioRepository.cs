using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public async Task<Usuario?> GetByGoogleIdAsync(string googleId)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.GoogleId == googleId);
        }
    }
}