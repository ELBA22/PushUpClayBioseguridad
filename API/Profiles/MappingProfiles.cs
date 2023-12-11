using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Categoriapersona, CategoriapersonaDto>().ReverseMap();
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Contactopersona, ContactoPersonaDto>().ReverseMap();
            CreateMap<Contrato, ContratoDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Direccionpersona, DireccionPersonaDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<Programacion, ProgramacionDto>().ReverseMap();
            CreateMap<Tipocontacto, TipoContactoDto>().ReverseMap();
            CreateMap<Tipodireccion, TipoDireccionDto>().ReverseMap();
            CreateMap<Tipopersona, TipoPersonaDto>().ReverseMap();
            CreateMap<Turno, TurnoDto>().ReverseMap();
        }
        
    }
}