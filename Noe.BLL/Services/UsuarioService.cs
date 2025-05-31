using AutoMapper;
using Noe.BLL.Interfaces;
using Noe.BLL.Services;
using Noe.DAL.Interfaces;
using Noe.Models.DTOs;
using Noe.Models.Entities;

namespace Noe.BLL.Services
{
    public class UsuarioService : BaseService<Usuario, UsuarioDto, UsuarioCreateDto, UsuarioUpdateDto>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) 
            : base(usuarioRepository, mapper)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        public async Task<UsuarioDto?> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }
        
        public async Task<UsuarioDto?> GetByGoogleIdAsync(string googleId)
        {
            var usuario = await _usuarioRepository.GetByGoogleIdAsync(googleId);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }
    }
}