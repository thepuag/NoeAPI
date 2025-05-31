using Noe.Models.Entities;

namespace Noe.DAL.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> GetByGoogleIdAsync(string googleId);
    }
}