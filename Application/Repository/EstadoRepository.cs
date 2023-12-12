
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        protected readonly DbAppContext _context;

        public EstadoRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados
                .ToListAsync();
        }

        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await _context.Estados
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }