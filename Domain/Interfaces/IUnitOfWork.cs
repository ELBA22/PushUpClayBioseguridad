using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriapersona Categoriapersonas {get;}
        ICiudad Ciudades {get;}
        IContactopersona Contactopersonas {get;}
        IContrato Contratos {get;}
        IDepartamento Departamentos {get;}
        IDireccionpersona Direccionpersonas {get;}
        IEstado Estados {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IProgramacion Programaciones {get;}
        ITipoContacto TipoContactoS {get;}
        ITipoDireccion TipoDirecciones {get;}
        ITipoPersona TipoPersonas {get;}
        ITurno Turnos {get;}

        Task<int> SaveAsync();
    }
}