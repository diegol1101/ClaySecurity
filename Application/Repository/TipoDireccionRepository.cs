
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class TipoDireccionRepository : GenericRepository<Tipodireccion>, ITipodireccion
    {
        protected readonly DbAppContext _context;

        public TipoDireccionRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Tipodireccion>> GetAllAsync()
        {
            return await _context.Tipodireccions
                .ToListAsync();
        }

        public override async Task<Tipodireccion> GetByIdAsync(int id)
        {
            return await _context.Tipodireccions
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }