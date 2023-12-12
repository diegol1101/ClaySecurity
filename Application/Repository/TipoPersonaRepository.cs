
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class TipoPersonaRepository : GenericRepository<Tipopersona>, ITipopersona
    {
        protected readonly DbAppContext _context;

        public TipoPersonaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Tipopersona>> GetAllAsync()
        {
            return await _context.Tipopersonas
                .ToListAsync();
        }

        public override async Task<Tipopersona> GetByIdAsync(int id)
        {
            return await _context.Tipopersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }