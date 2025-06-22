using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class ProyectoTecnologiaRepository : BaseRepository<ProyectoTecnologia>, IProyectoTecnologiaRepository
    {
        public ProyectoTecnologiaRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}