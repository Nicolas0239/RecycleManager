using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleManager.Api.DTOs;
using RecycleManager.Api.Services;

namespace RecycleManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionPointController: ControllerBase
    {
        private readonly ICollectionPointService _service;
        private readonly IValidator<CollectionPointCreateDto> _validatorCreate;
        private readonly IValidator<CollectionPointDto> _validatorDto;

        public CollectionPointController(ICollectionPointService service, IValidator<CollectionPointCreateDto> validatorCreate, IValidator<CollectionPointDto> validatorDto)
        {
            _service = service;
            _validatorCreate = validatorCreate;
            _validatorDto = validatorDto;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetPagedAsync(page, pageSize);

            return Ok(new
            {
                data = result.Items,
                total = result.Total,
                page,
                pageSize
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CollectionPointCreateDto dto)
        {
            var validationResult = await _validatorCreate.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.CollectionPointId }, created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CollectionPointDto dto)
        {
            if (id != dto.CollectionPointId)
                return BadRequest("O ID da rota não confere com o ID do objeto.");

            // 1. Validação Manual
            var validationResult = await _validatorDto.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var updated = await _service.UpdateAsync(id, dto);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent(); 
        }
    }
}
