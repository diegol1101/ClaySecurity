using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EstadoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EstadoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
    {
        var estado = await unitofwork.Estados.GetAllAsync();
        return mapper.Map<List<EstadoDto>>(estado);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EstadoDto>> Get(int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        if (estado == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EstadoDto>(estado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Post(EstadoDto estadoDto)
    {
        var estado = this.mapper.Map<Estado>(estadoDto);
        this.unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();
        if (estado == null)
        {
            return BadRequest();
        }
        estadoDto.Id = estado.Id;
        return CreatedAtAction(nameof(Post), new { id = estadoDto.Id }, estadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto estadoDto)
    {
        if (estadoDto == null)
        {
            return NotFound();
        }
        var estado = this.mapper.Map<Estado>(estadoDto);
        unitofwork.Estados.Update(estado);
        await unitofwork.SaveAsync();
        return estadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        if (estado == null)
        {
            return NotFound();
        }
        unitofwork.Estados.Remove(estado);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
