using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleManager.Api.DTOs;
using RecycleManager.Api.Services;

namespace RecycleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialsController : ControllerBase
{
    private readonly IMaterialService _service;
    private readonly IValidator<MaterialCreateDto> _validatorCreate;
    private readonly IValidator<MaterialDto> _validatorDto;

    public MaterialsController(IMaterialService service, IValidator<MaterialCreateDto> validatorCreate, IValidator<MaterialDto> validatorDto)
    {
        _service = service;
        _validatorCreate = validatorCreate;
        _validatorDto = validatorDto;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetPagedAsync(page, pageSize);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MaterialCreateDto dto)
    {
        var validation = await _validatorCreate.ValidateAsync(dto);
        if (!validation.IsValid) return BadRequest(validation.Errors.Select(e => e.ErrorMessage));
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var material = await _service.GetByIdAsync(id);

        if (material == null)
            return NotFound();

        return Ok(material); 
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MaterialDto dto)
    {
        var validation = await _validatorDto.ValidateAsync(dto);
        if (!validation.IsValid) return BadRequest(validation.Errors.Select(e => e.ErrorMessage));
        if (id != dto.Id)
            return BadRequest("O ID da rota não coincide com o ID do corpo da requisição.");

        
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
