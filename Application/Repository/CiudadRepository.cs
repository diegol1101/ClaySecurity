
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
    {
        protected readonly DbAppContext _context;

        public CiudadRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await _context.Ciudads
                .ToListAsync();
        }

        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context.Ciudads
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }