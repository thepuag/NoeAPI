using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class ProyectoTecnologiaController : BaseController<ProyectoTecnologiaDto, ProyectoTecnologiaCreateDto, ProyectoTecnologiaUpdateDto>
    {
        private readonly IProyectoTecnologiaService _proyectoTecnologiaService;

        public ProyectoTecnologiaController(IProyectoTecnologiaService ProyectoTecnologiaService) : base(ProyectoTecnologiaService)
        {
            _proyectoTecnologiaService = ProyectoTecnologiaService;
        }
        
        protected override object GetItemId(ProyectoTecnologiaDto item)
        {
            return item.Id;
        }
              
       
    }
}