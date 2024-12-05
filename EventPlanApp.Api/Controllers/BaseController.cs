using AutoMapper;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TDTO, TEntity> : ControllerBase
        where TDTO : class
        where TEntity : class
    {
        private readonly IService<TDTO> _service;
        private readonly IMapper _mapper;

        protected BaseController(IService<TDTO> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDTO>>> GetAll()
        {
            var dtos = await _service.GetAll();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDTO>> GetById(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound($"Resource with ID {id} not found.");

            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDTO>> Create([FromBody] TDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDto = await _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = GetIdFromDTO(createdDto) }, createdDto);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TDTO>> Update(int id, [FromBody] TDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedDto = await _service.Update(id, dto);
                return Ok(updatedDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound($"Resource with ID {id} not found.");

            return NoContent();
        }

        // Método auxiliar para extrair o ID do DTO
        protected abstract object GetIdFromDTO(TDTO dto);
    }
}
