using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ContactoPersonaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContactoPersonaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
    {
        var contactoPersona = await unitofwork.ContactoPersonas.GetAllAsync();
        return mapper.Map<List<ContactoPersonaDto>>(contactoPersona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
    {
        var contactoPersona = await unitofwork.ContactoPersonas.GetByIdAsync(id);
        if (contactoPersona == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ContactoPersonaDto>(contactoPersona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Contactopersona>> Post(ContactoPersonaDto contactoPersonaDto)
    {
        var contactoPersona = this.mapper.Map<Contactopersona>(contactoPersonaDto);
        this.unitofwork.ContactoPersonas.Add(contactoPersona);
        await unitofwork.SaveAsync();
        if (contactoPersona == null)
        {
            return BadRequest();
        }
        contactoPersonaDto.Id = contactoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = contactoPersonaDto.Id }, contactoPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto contactoPersonaDto)
    {
        if (contactoPersonaDto == null)
        {
            return NotFound();
        }
        var contactoPersona = this.mapper.Map<Contactopersona>(contactoPersonaDto);
        unitofwork.ContactoPersonas.Update(contactoPersona);
        await unitofwork.SaveAsync();
        return contactoPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var contactoPersona = await unitofwork.ContactoPersonas.GetByIdAsync(id);
        if (contactoPersona == null)
        {
            return NotFound();
        }
        unitofwork.ContactoPersonas.Remove(contactoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}