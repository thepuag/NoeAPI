using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noe.BLL.Interfaces;

namespace Noe.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public abstract class BaseController<TDto, TCreateDto, TUpdateDto> : ControllerBase
        where TDto : class
    {
        protected readonly IBaseService<TDto, TCreateDto, TUpdateDto> _service;
        
        protected BaseController(IBaseService<TDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetAll()
        {
            try
            {
                var items = await _service.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetById(int id)
        {
            try
            {
                var item = await _service.GetByIdAsync(id);
                if (item == null)
                    return NotFound();
                
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("bystring/{column}/{value}")]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetByColumnString(string column, string value)
        {
            try
            {
                var items = await _service.GetByColumnStringAsync(column, value);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("byint/{column}/{value}")]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> GetByColumnInt(string column, int value)
        {
            try
            {
                var items = await _service.GetByColumnIntAsync(column, value);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPost]
        public virtual async Task<ActionResult<TDto>> Create([FromBody] TCreateDto createDto)
        {
            try
            {
                var item = await _service.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = GetItemId(item) }, item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPut]
        public virtual async Task<ActionResult<TDto>> Update([FromBody] TUpdateDto updateDto)
        {
            try
            {
                var item = await _service.UpdateAsync(updateDto);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result)
                    return NotFound();
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        protected abstract object GetItemId(TDto item);
    }
}