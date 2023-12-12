
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

    public class ContactoPersonaRepository : GenericRepository<Contactopersona>, IContactopersona
    {
        protected readonly DbAppContext _context;

        public ContactoPersonaRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Contactopersona>> GetAllAsync()
        {
            return await _context.Contactopersonas
                .ToListAsync();
        }

        public override async Task<Contactopersona> GetByIdAsync(int id)
        {
            return await _context.Contactopersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }