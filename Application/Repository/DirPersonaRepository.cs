
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class DirPersonaRepository : GenericRepository<Dirpersona>, IDirpersona
    {
        protected readonly DbAppContext _context;

        public DirPersonaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Dirpersona>> GetAllAsync()
        {
            return await _context.Dirpersonas
                .ToListAsync();
        }

        public override async Task<Dirpersona> GetByIdAsync(int id)
        {
            return await _context.Dirpersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }