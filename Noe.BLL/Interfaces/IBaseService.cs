namespace Noe.BLL.Interfaces
{
    public interface IBaseService<TDto, TCreateDto, TUpdateDto> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetByColumnStringAsync(string columnName, string value);
        Task<IEnumerable<TDto>> GetByColumnIntAsync(string columnName, int value);
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task<TDto> UpdateAsync(TUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}