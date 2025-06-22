using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class TecnologiaController : BaseController<TecnologiaDto, TecnologiaCreateDto, TecnologiaUpdateDto>
    {
        private readonly ITecnologiaService _tecnologiaService;

        public TecnologiaController(ITecnologiaService TecnologiaService) : base(TecnologiaService)
        {
            _tecnologiaService = TecnologiaService;
        }
        
        protected override object GetItemId(TecnologiaDto item)
        {
            return item.Id;
        }
              
       
    }
}