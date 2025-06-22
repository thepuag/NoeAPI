using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class ProyectoController : BaseController<ProyectoDto, ProyectoCreateDto, ProyectoUpdateDto>
    {
        private readonly IProyectoService _proyectoService;

        public ProyectoController(IProyectoService ProyectoService) : base(ProyectoService)
        {
            _proyectoService = ProyectoService;
        }
        
        protected override object GetItemId(ProyectoDto item)
        {
            return item.Id;
        }
              
       
    }
}