using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class AlmacenesController : BaseController<AlmacenDto, AlmacenCreateDto, AlmacenUpdateDto>
    {
         private readonly IAlmacenService _almacenService;
        
        public AlmacenesController(IAlmacenService almacenService) : base(almacenService)
        {
            _almacenService = almacenService;
        }
        
        [HttpGet("producto/{productoId}")]
        public async Task<ActionResult<IEnumerable<AlmacenDto>>> GetByProductoId(int productoId)
        {
            try
            {
                var almacenes = await _almacenService.GetByProductoIdAsync(productoId);
                return Ok(almacenes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("producto/{productoId}/single")]
        public async Task<ActionResult<AlmacenDto>> GetByProductoIdSingle(int productoId)
        {
            try
            {
                var almacen = await _almacenService.GetByProductoIdSingleAsync(productoId);
                if (almacen == null)
                    return NotFound();
                
                return Ok(almacen);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        protected override object GetItemId(AlmacenDto item)
        {
            return item.Id;
        }
    }
}