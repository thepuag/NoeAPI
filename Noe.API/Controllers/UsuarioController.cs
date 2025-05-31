using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    public class UsuariosController : BaseController<UsuarioDto, UsuarioCreateDto, UsuarioUpdateDto>
    {
        private readonly IUsuarioService _usuarioService;
        
        public UsuariosController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UsuarioDto>> GetByEmail(string email)
        {
            try
            {
                var usuario = await _usuarioService.GetByEmailAsync(email);
                if (usuario == null)
                    return NotFound();
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("google/{googleId}")]
        public async Task<ActionResult<UsuarioDto>> GetByGoogleId(string googleId)
        {
            try
            {
                var usuario = await _usuarioService.GetByGoogleIdAsync(googleId);
                if (usuario == null)
                    return NotFound();
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        protected override object GetItemId(UsuarioDto item)
        {
            return item.Id;
        }
    }
}