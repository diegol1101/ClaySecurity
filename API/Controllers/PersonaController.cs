using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var persona = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<PersonaDto>>(persona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Get(int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        if (persona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PersonaDto>(persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Persona>> Post(PersonaDto personaDto)
    {
        var persona = this.mapper.Map<Persona>(personaDto);
        this.unitofwork.Personas.Add(persona);
        await unitofwork.SaveAsync();
        if (persona == null)
        {
            return BadRequest();
        }
        personaDto.Id = persona.Id;
        return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
    {
        if (personaDto == null)
        {
            return NotFound();
        }
        var persona = this.mapper.Map<Persona>(personaDto);
        unitofwork.Personas.Update(persona);
        await unitofwork.SaveAsync();
        return personaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        if (persona == null)
        {
            return NotFound();
        }
        unitofwork.Personas.Remove(persona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("Con1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<object>>> GetCon1()
    {
        var persona = await unitofwork.Personas.GetCon1();
        return mapper.Map<List<object>>(persona);
    }
}