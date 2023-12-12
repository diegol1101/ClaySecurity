using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersona :IGenericRepository<Persona>
    {
        Task<IEnumerable<object>> GetCon1 ();
        
    }
}