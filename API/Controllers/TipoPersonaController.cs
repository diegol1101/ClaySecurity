using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoPersonaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoPersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetAllAsync();
        return mapper.Map<List<TipoPersonaDto>>(tipoPersona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);
        if (tipoPersona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Tipopersona>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<Tipopersona>(tipoPersonaDto);
        this.unitofwork.TipoPersonas.Add(tipoPersona);
        await unitofwork.SaveAsync();
        if (tipoPersona == null)
        {
            return BadRequest();
        }
        tipoPersonaDto.Id = tipoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoPersonaDto.Id }, tipoPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto tipoPersonaDto)
    {
        if (tipoPersonaDto == null)
        {
            return NotFound();
        }
        var tipoPersona = this.mapper.Map<Tipopersona>(tipoPersonaDto);
        unitofwork.TipoPersonas.Update(tipoPersona);
        await unitofwork.SaveAsync();
        return tipoPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);
        if (tipoPersona == null)
        {
            return NotFound();
        }
        unitofwork.TipoPersonas.Remove(tipoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}