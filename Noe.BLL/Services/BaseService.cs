using AutoMapper;
using Noe.DAL.Interfaces;

namespace Noe.BLL.Services
{
    public abstract class BaseService<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        
        protected BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        
        public virtual async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }
        
        public virtual async Task<IEnumerable<TDto>> GetByColumnStringAsync(string columnName, string value)
        {
            var entities = await _repository.GetByColumnStringAsync(columnName, value);
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        
        public virtual async Task<IEnumerable<TDto>> GetByColumnIntAsync(string columnName, int value)
        {
            var entities = await _repository.GetByColumnIntAsync(columnName, value);
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        
        public virtual async Task<TDto> CreateAsync(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            var createdEntity = await _repository.CreateAsync(entity);
            return _mapper.Map<TDto>(createdEntity);
        }
        
        public virtual async Task<TDto> UpdateAsync(TUpdateDto updateDto)
        {
            var entity = _mapper.Map<TEntity>(updateDto);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<TDto>(updatedEntity);
        }
        
        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}