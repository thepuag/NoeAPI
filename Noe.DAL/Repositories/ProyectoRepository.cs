using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class ProyectoRepository : BaseRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}