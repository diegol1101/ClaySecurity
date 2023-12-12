using API.Dtos;

using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProgramacionController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProgramacionController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
    {
        var programacion = await unitofwork.Programaciones.GetAllAsync();
        return mapper.Map<List<ProgramacionDto>>(programacion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProgramacionDto>> Get(int id)
    {
        var programacion = await unitofwork.Programaciones.GetByIdAsync(id);
        if (programacion == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ProgramacionDto>(programacion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Programacion>> Post(ProgramacionDto programacionDto)
    {
        var programacion = this.mapper.Map<Programacion>(programacionDto);
        this.unitofwork.Programaciones.Add(programacion);
        await unitofwork.SaveAsync();
        if (programacion == null)
        {
            return BadRequest();
        }
        programacionDto.Id = programacion.Id;
        return CreatedAtAction(nameof(Post), new { id = programacionDto.Id }, programacionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody] ProgramacionDto programacionDto)
    {
        if (programacionDto == null)
        {
            return NotFound();
        }
        var programacion = this.mapper.Map<Programacion>(programacionDto);
        unitofwork.Programaciones.Update(programacion);
        await unitofwork.SaveAsync();
        return programacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var programacion = await unitofwork.Programaciones.GetByIdAsync(id);
        if (programacion == null)
        {
            return NotFound();
        }
        unitofwork.Programaciones.Remove(programacion);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
