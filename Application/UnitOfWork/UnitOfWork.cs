using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbAppContext _context;

    private CategoriaPersonaRepository _categoriaPersonas;
    private CiudadRepository _ciudades;
    private ContactoPersonaRepository _contactoPersonas;
    private ContratoRepository _contratos;
    private DepartamentoRepository _departamentos;
    private DirPersonaRepository _dirPersonas;
    private EstadoRepository _estados;
    private PaisRepository _paises;
    private PersonaRepository _personas;
    private ProgramacionRepository _programaciones;
    private RolRepository _roles;
    private TipoContactoRepository _tipoContactos;
    private TipoDireccionRepository _tipoDirecciones;
    private TipoPersonaRepository _tipoPersonas;
    private TurnoRepository _turnos;
    private UserRepository _users;

    public UnitOfWork(DbAppContext context)
    {
        _context = context;
    }


    public ICategoriapersona CategoriaPersonas
    {
        get
        {
            if (_categoriaPersonas == null)
            {
                _categoriaPersonas = new CategoriaPersonaRepository(_context);
            }
            return _categoriaPersonas;
        }
    }


    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }


    public IContactopersona ContactoPersonas
    {
        get
        {
            if (_contactoPersonas == null)
            {
                _contactoPersonas = new ContactoPersonaRepository(_context);
            }
            return _contactoPersonas;
        }
    }

    public IContrato Contratos
    {
        get
        {
            if (_contratos == null)
            {
                _contratos = new ContratoRepository(_context);
            }
            return _contratos;
        }
    }


    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }


    public IDirpersona DirPersonas
    {
        get
        {
            if (_dirPersonas == null)
            {
                _dirPersonas = new DirPersonaRepository(_context);
            }
            return _dirPersonas;
        }
    }


    public IEstado Estados
    {
        get
        {
            if (_estados == null)
            {
                _estados = new EstadoRepository(_context);
            }
            return _estados;
        }
    }


    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }


    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(_context);
            }
            return _personas;
        }
    }

    public IProgramacion Programaciones
    {
        get
        {
            if (_programaciones == null)
            {
                _programaciones = new ProgramacionRepository(_context);
            }
            return _programaciones;
        }
    }


    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }


    public ITipocontacto TipoContactos
    {
        get
        {
            if (_tipoContactos == null)
            {
                _tipoContactos = new TipoContactoRepository(_context);
            }
            return _tipoContactos;
        }
    }


    public ITipodireccion TipoDirecciones
    {
        get
        {
            if (_tipoDirecciones == null)
            {
                _tipoDirecciones = new TipoDireccionRepository(_context);
            }
            return _tipoDirecciones;
        }
    }


    public ITipopersona TipoPersonas
    {
        get
        {
            if (_tipoPersonas == null)
            {
                _tipoPersonas = new TipoPersonaRepository(_context);
            }
            return _tipoPersonas;
        }
    }


    public ITurno Turnos
    {
        get
        {
            if (_turnos == null)
            {
                _turnos = new TurnoRepository(_context);
            }
            return _turnos;
        }
    }


    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}