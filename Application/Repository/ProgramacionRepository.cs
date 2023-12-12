
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
    {
        protected readonly DbAppContext _context;

        public ProgramacionRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Programacion>> GetAllAsync()
        {
            return await _context.Programacions
                .ToListAsync();
        }

        public override async Task<Programacion> GetByIdAsync(int id)
        {
            return await _context.Programacions
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }