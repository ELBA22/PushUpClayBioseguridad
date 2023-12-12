using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var persona = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(persona);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return _mapper.Map<PersonaDto>(persona);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            _unitOfWork.Personas.Add(persona);
            await _unitOfWork.SaveAsync();
            if (personaDto == null)
            {
                return BadRequest();
            }
            personaDto.Id = personaDto.Id;
            return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null)
            {
                return NotFound();
            }
            var persona = _mapper.Map<Persona>(personaDto);
            _unitOfWork.Personas.Update(persona);
            await _unitOfWork.SaveAsync();
            return personaDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Persona>> Delete(int id)
        {
            var persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            _unitOfWork.Personas.Remove(persona);
            await _unitOfWork.SaveAsync();
            return NoContent();

        }



    }
}