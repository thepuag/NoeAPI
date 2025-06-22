using Microsoft.EntityFrameworkCore;
using Noe.DAL.Context;
using Noe.DAL.Interfaces;
using Noe.Models.Entities;

namespace Noe.DAL.Repositories
{
    public class TecnologiaRepository : BaseRepository<Tecnologia>, ITecnologiaRepository
    {
        public TecnologiaRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}