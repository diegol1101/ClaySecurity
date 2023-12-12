
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class CategoriaPersonaRepository : GenericRepository<Categoriapersona>, ICategoriapersona
    {
        protected readonly DbAppContext _context;

        public CategoriaPersonaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Categoriapersona>> GetAllAsync()
        {
            return await _context.Categoriapersonas
                .ToListAsync();
        }

        public override async Task<Categoriapersona> GetByIdAsync(int id)
        {
            return await _context.Categoriapersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }