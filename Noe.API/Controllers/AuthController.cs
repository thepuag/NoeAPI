using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;

namespace Noe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("google")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> GoogleLogin([FromBody] GoogleAuthDto googleAuthDto)
        {
            try
            {
                var result = await _authService.GoogleLoginAsync(googleAuthDto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("me")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            var userId = User.FindFirst("sub")?.Value ?? User.FindFirst("NameIdentifier")?.Value;
            var userName = User.FindFirst("name")?.Value ?? User.Identity?.Name;
            var userEmail = User.FindFirst("email")?.Value;
            
            return Ok(new 
            { 
                id = userId,
                name = userName,
                email = userEmail
            });
        }
    }
}