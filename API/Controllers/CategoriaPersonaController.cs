using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaPersonaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CategoriaPersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get()
    {
        var categoriaPersona = await unitofwork.CategoriaPersonas.GetAllAsync();
        return mapper.Map<List<CategoriaPersonaDto>>(categoriaPersona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
    {
        var categoriaPersona = await unitofwork.CategoriaPersonas.GetByIdAsync(id);
        if (categoriaPersona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CategoriaPersonaDto>(categoriaPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Categoriapersona>> Post(CategoriaPersonaDto categoriaPersonaDto)
    {
        var categoriaPersona = this.mapper.Map<Categoriapersona>(categoriaPersonaDto);
        this.unitofwork.CategoriaPersonas.Add(categoriaPersona);
        await unitofwork.SaveAsync();
        if (categoriaPersona == null)
        {
            return BadRequest();
        }
        categoriaPersonaDto.Id = categoriaPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = categoriaPersonaDto.Id }, categoriaPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody] CategoriaPersonaDto categoriaPersonaDto)
    {
        if (categoriaPersonaDto == null)
        {
            return NotFound();
        }
        var categoriaPersona = this.mapper.Map<Categoriapersona>(categoriaPersonaDto);
        unitofwork.CategoriaPersonas.Update(categoriaPersona);
        await unitofwork.SaveAsync();
        return categoriaPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var categoriaPersona = await unitofwork.CategoriaPersonas.GetByIdAsync(id);
        if (categoriaPersona == null)
        {
            return NotFound();
        }
        unitofwork.CategoriaPersonas.Remove(categoriaPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}