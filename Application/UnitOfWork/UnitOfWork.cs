using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositorys;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly bioseContext _context;
        private CategoriaPersonaRepository  _categoriapersonas;
        private CiudadRepository  _ciudades;
        private ContactoPersonaRepository _contactopersonas;
        private ContratoRepository  _contratos;
        private DepartamentoRepository _departamentos;
        private DireccionPersonaRepository  _direccionpersonas;
        private EstadoRepository  _estados;
        private PaisRepository  _paises;
        private PersonaRepository _personas;
        private ProgramacionRepository _programaciones;
        private RefreshTokenRepository _refreshtokens;
        private RolRepository _rols;
        private TipoContactoRepository _tipocontactos;

        private TipoDireccionRepository _tipodirecciones;
        private TipoPersonaRepository _tipopersonas;
        private TurnoRepository _turnos;

        private UserRepository _users;

        public UnitOfWork(bioseContext context)
        {
            _context = context;
        }

        public ICategoriapersona Categoriapersonas
        {
            get
            {
                if(_categoriapersonas == null)
                {
                    _categoriapersonas = new CategoriaPersonaRepository(_context);
                }
                return _categoriapersonas;
            }
        }

        public ICiudad Ciudades
        {
            get
            {
                if(_ciudades == null)
                {
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }

        public IContactopersona Contactopersonas
        {
            get{
                if(_contactopersonas == null)
                {
                    _contactopersonas = new ContactoPersonaRepository(_context);
                }
                return _contactopersonas;
            }
        }

        public IContrato Contratos
        {
            get{
                if(_contratos == null)
                {
                    _contratos = new ContratoRepository(_context);
                }
                return   _contratos;
            }
        }

        public IDepartamento Departamentos
        {
            get{
                if(_departamentos == null)
                {
                    _contratos = new DepartamentoRepository (_context);
                }
                return   _departamentos;
            }
        }

        public IDireccionpersona Direccionpersonas
        {
            get{
                if(_direccionpersonas == null)
                {
                    _direccionpersonas = new DireccionPersonaRepository (_context);
                }
                return (IDireccionpersona)_direccionpersonas;
            }
        }

        public IEstado Estados
        {
            get{
                if(_estados == null)
                {
                    _estados = new EstadoRepository (_context);
                }
                return   _estados;
            }
        }

        public IPais Paises
        {
            get{
                if(_paises == null)
                {
                    _paises  = new PaisRepository(_context);
                }
                return   _paises ;
            }
        }

        public IPersona Personas
        {
            get{
                if(_personas == null)
                {
                   _personas = new PersonaRepository(_context);
                }
                return   _personas ;
            }
        }

        public IProgramacion Programaciones
        {
            get{
                if(_programaciones == null)
                {
                  _programaciones = new ProgramacionRepository(_context);
                }
                return   _programaciones ;
            }
        }

        public IRefreshToken  RefreshTokens
        {
            get{
                if(_refreshtokens == null)
                {
                  _refreshtokens = new RefreshTokenRepository(_context);
                }
                return (IRefreshToken)_refreshtokens ;
            }
        }

        public IRol Roles
        {
            get{
                if(_rols == null)
                {
                  _rols  = new RolRepository(_context);
                }
                return   _rols  ;
            }
        }

        public ITipoContacto TipoContactos
        {
            get{
                if(_tipocontactos == null)
                {
                  _tipocontactos  = new TipoContactoRepository(_context);
                }
                return   _tipocontactos  ;
            }
        }

        public ITipoContacto TipoContactoS => throw new NotImplementedException();

        public ITipoDireccion TipoDirecciones
        {
            get{
                if(_tipodirecciones == null)
                {
                  _tipodirecciones  = new TipoDireccionRepository(_context);
                }
                return   _tipodirecciones  ;
            }
        }

        public ITipoPersona TipoPersonas
        {
            get{
                if(_tipopersonas == null)
                {
                  _tipopersonas  = new TipoPersonaRepository(_context);
                }
                return   _tipopersonas  ;
            }
        }

        public ITurno Turnos
        {
            get{
                if(_turnos == null)
                {
                  _turnos  = new TurnoRepository(_context);
                }
                return   _turnos  ;
            }
        }

        public IUser Users
        {
            get{
                if(_users == null)
                {
                  _users  = new UserRepository(_context);
                }
                return   _users  ;
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
}