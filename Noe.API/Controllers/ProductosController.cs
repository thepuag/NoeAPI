using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class ProductosController : BaseController<ProductoDto, ProductoCreateDto, ProductoUpdateDto>
    {
        private readonly IProductoService _productoService;
        
        public ProductosController(IProductoService productoService) : base(productoService)
        {
            _productoService = productoService;
        }
        
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetActiveProducts()
        {
            try
            {
                var productos = await _productoService.GetActiveProductsAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        protected override object GetItemId(ProductoDto item)
        {
            return item.Id;
        }
    }
}