using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

    public interface IUnitOfWork
    {   
        ICategoriapersona CategoriaPersonas {get;}
        ICiudad Ciudades {get;}
        IContactopersona ContactoPersonas {get;}
        IContrato Contratos {get;}
        IDepartamento Departamentos {get;}
        IDirpersona DirPersonas {get;}
        IEstado Estados {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IProgramacion Programaciones {get;}
        IRol Roles {get;}
        ITipocontacto TipoContactos {get;}
        ITipodireccion TipoDirecciones {get;}
        ITipopersona TipoPersonas {get;}
        ITurno Turnos {get;}
        IUser Users{get;}
        Task<int> SaveAsync();
    }
