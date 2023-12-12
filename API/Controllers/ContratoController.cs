using API.Dtos;

using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ContratoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContratoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ContratoDto>>> Get()
    {
        var contrato = await unitofwork.Contratos.GetAllAsync();
        return mapper.Map<List<ContratoDto>>(contrato);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ContratoDto>> Get(int id)
    {
        var contrato = await unitofwork.Contratos.GetByIdAsync(id);
        if (contrato == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ContratoDto>(contrato);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Contrato>> Post(ContratoDto contratoDto)
    {
        var contrato = this.mapper.Map<Contrato>(contratoDto);
        this.unitofwork.Contratos.Add(contrato);
        await unitofwork.SaveAsync();
        if (contrato == null)
        {
            return BadRequest();
        }
        contratoDto.Id = contrato.Id;
        return CreatedAtAction(nameof(Post), new { id = contratoDto.Id }, contratoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody] ContratoDto contratoDto)
    {
        if (contratoDto == null)
        {
            return NotFound();
        }
        var contrato = this.mapper.Map<Contrato>(contratoDto);
        unitofwork.Contratos.Update(contrato);
        await unitofwork.SaveAsync();
        return contratoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var contrato = await unitofwork.Contratos.GetByIdAsync(id);
        if (contrato == null)
        {
            return NotFound();
        }
        unitofwork.Contratos.Remove(contrato);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
