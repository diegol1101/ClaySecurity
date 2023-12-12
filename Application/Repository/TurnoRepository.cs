
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class TurnoRepository : GenericRepository<Turno>, ITurno
    {
        protected readonly DbAppContext _context;

        public TurnoRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await _context.Turnos
                .ToListAsync();
        }

        public override async Task<Turno> GetByIdAsync(int id)
        {
            return await _context.Turnos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }