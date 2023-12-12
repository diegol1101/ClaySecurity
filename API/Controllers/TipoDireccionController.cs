using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoDireccionController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoDireccionController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoDireccionDto>>> Get()
    {
        var tipoDireccion = await unitofwork.TipoDirecciones.GetAllAsync();
        return mapper.Map<List<TipoDireccionDto>>(tipoDireccion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoDireccionDto>> Get(int id)
    {
        var tipoDireccion = await unitofwork.TipoDirecciones.GetByIdAsync(id);
        if (tipoDireccion == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoDireccionDto>(tipoDireccion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Tipodireccion>> Post(TipoDireccionDto tipoDireccionDto)
    {
        var tipoDireccion = this.mapper.Map<Tipodireccion>(tipoDireccionDto);
        this.unitofwork.TipoDirecciones.Add(tipoDireccion);
        await unitofwork.SaveAsync();
        if (tipoDireccion == null)
        {
            return BadRequest();
        }
        tipoDireccionDto.Id = tipoDireccion.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoDireccionDto.Id }, tipoDireccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoDireccionDto>> Put(int id, [FromBody] TipoDireccionDto tipoDireccionDto)
    {
        if (tipoDireccionDto == null)
        {
            return NotFound();
        }
        var tipoDireccion = this.mapper.Map<Tipodireccion>(tipoDireccionDto);
        unitofwork.TipoDirecciones.Update(tipoDireccion);
        await unitofwork.SaveAsync();
        return tipoDireccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var tipoDireccion = await unitofwork.TipoDirecciones.GetByIdAsync(id);
        if (tipoDireccion == null)
        {
            return NotFound();
        }
        unitofwork.TipoDirecciones.Remove(tipoDireccion);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}