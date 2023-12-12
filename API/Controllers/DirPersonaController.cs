using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DirPersonaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DirPersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DirPersonaDto>>> Get()
    {
        var dirPersona = await unitofwork.DirPersonas.GetAllAsync();
        return mapper.Map<List<DirPersonaDto>>(dirPersona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DirPersonaDto>> Get(int id)
    {
        var dirPersona = await unitofwork.DirPersonas.GetByIdAsync(id);
        if (dirPersona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DirPersonaDto>(dirPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Dirpersona>> Post(DirPersonaDto dirPersonaDto)
    {
        var dirPersona = this.mapper.Map<Dirpersona>(dirPersonaDto);
        this.unitofwork.DirPersonas.Add(dirPersona);
        await unitofwork.SaveAsync();
        if (dirPersona == null)
        {
            return BadRequest();
        }
        dirPersonaDto.Id = dirPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = dirPersonaDto.Id }, dirPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DirPersonaDto>> Put(int id, [FromBody] DirPersonaDto dirPersonaDto)
    {
        if (dirPersonaDto == null)
        {
            return NotFound();
        }
        var dirPersona = this.mapper.Map<Dirpersona>(dirPersonaDto);
        unitofwork.DirPersonas.Update(dirPersona);
        await unitofwork.SaveAsync();
        return dirPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var dirPersona = await unitofwork.DirPersonas.GetByIdAsync(id);
        if (dirPersona == null)
        {
            return NotFound();
        }
        unitofwork.DirPersonas.Remove(dirPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
