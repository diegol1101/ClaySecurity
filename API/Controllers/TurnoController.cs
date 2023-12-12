using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TurnoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TurnoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TurnoDto>>> Get()
    {
        var turno = await unitofwork.Turnos.GetAllAsync();
        return mapper.Map<List<TurnoDto>>(turno);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TurnoDto>> Get(int id)
    {
        var turno = await unitofwork.Turnos.GetByIdAsync(id);
        if (turno == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TurnoDto>(turno);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Turno>> Post(TurnoDto turnoDto)
    {
        var turno = this.mapper.Map<Turno>(turnoDto);
        this.unitofwork.Turnos.Add(turno);
        await unitofwork.SaveAsync();
        if (turno == null)
        {
            return BadRequest();
        }
        turnoDto.Id = turno.Id;
        return CreatedAtAction(nameof(Post), new { id = turnoDto.Id }, turnoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody] TurnoDto turnoDto)
    {
        if (turnoDto == null)
        {
            return NotFound();
        }
        var turno = this.mapper.Map<Turno>(turnoDto);
        unitofwork.Turnos.Update(turno);
        await unitofwork.SaveAsync();
        return turnoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var turno = await unitofwork.Turnos.GetByIdAsync(id);
        if (turno == null)
        {
            return NotFound();
        }
        unitofwork.Turnos.Remove(turno);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}