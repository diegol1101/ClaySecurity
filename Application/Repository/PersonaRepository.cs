
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        protected readonly DbAppContext _context;

        public PersonaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .ToListAsync();
        }

        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<object>> GetCon1 ()
        {
            return await _context.Personas
                        .Where(p=>p.IdTipoPerNavigation.Descripcion.ToLower()=="empleado")
                        .ToListAsync();
        }
    }