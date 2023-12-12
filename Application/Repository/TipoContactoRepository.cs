
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class TipoContactoRepository : GenericRepository<Tipocontacto>, ITipocontacto
    {
        protected readonly DbAppContext _context;

        public TipoContactoRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Tipocontacto>> GetAllAsync()
        {
            return await _context.Tipocontactos
                .ToListAsync();
        }

        public override async Task<Tipocontacto> GetByIdAsync(int id)
        {
            return await _context.Tipocontactos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }