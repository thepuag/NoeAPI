using AutoMapper;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Noe.BLL.Interfaces;
using Noe.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Noe.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        
        public AuthService(IUsuarioService usuarioService, IConfiguration configuration, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        public async Task<AuthResponseDto> GoogleLoginAsync(GoogleAuthDto googleAuthDto)
        {
            var usuario = await ValidateGoogleTokenAsync(googleAuthDto.Token);
            
            if (usuario == null)
                throw new UnauthorizedAccessException("Token de Google inválido");
            
            // Verificar si el usuario existe
            var existingUser = await _usuarioService.GetByGoogleIdAsync(usuario.GoogleId);
            
            if (existingUser == null)
            {
                // Crear nuevo usuario
                var newUser = new UsuarioCreateDto
                {
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    GoogleId = usuario.GoogleId,
                    ImagenUrl = usuario.ImagenUrl
                };
                
                existingUser = await _usuarioService.CreateAsync(newUser);
            }
            
            var token = await GenerateJwtTokenAsync(existingUser);
            
            return new AuthResponseDto
            {
                Token = token,
                Usuario = existingUser,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }
        
        public async Task<string> GenerateJwtTokenAsync(UsuarioDto usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("GoogleId", usuario.GoogleId)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        public async Task<UsuarioDto?> ValidateGoogleTokenAsync(string token)
        {
            try
            {
                var clientId = _configuration["Google:ClientId"];
                var payload = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { clientId }
                });
                
                return new UsuarioDto
                {
                    Nombre = payload.Name,
                    Email = payload.Email,
                    GoogleId = payload.Subject,
                    ImagenUrl = payload.Picture ?? string.Empty
                };
            }
            catch
            {
                return null;
            }
        }
    }
}