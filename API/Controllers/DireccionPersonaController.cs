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
    public class DireccionPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DireccionPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DireccionPersonaDto>>> Get()
        {
            var direccionpersona = await _unitOfWork.Direccionpersonas.GetAllAsync();
            return _mapper.Map<List<DireccionPersonaDto>>(direccionpersona);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DireccionPersonaDto>> Get(int id)
        {
            var direccionpersona = await _unitOfWork.Direccionpersonas.GetByIdAsync(id);
            if (direccionpersona == null)
            {
                return NotFound();
            }
            return _mapper.Map<DireccionPersonaDto>(direccionpersona);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Direccionpersona>> Post(DireccionPersonaDto direccionPersonaDto)
        {
            var direccionpersona = _mapper.Map<Direccionpersona>(direccionPersonaDto);
            _unitOfWork.Direccionpersonas.Add(direccionpersona);
            await _unitOfWork.SaveAsync();
            if (direccionPersonaDto == null)
            {
                return BadRequest();
            }
            direccionPersonaDto.Id = direccionPersonaDto.Id;
            return CreatedAtAction(nameof(Post), new { id = direccionPersonaDto.Id }, direccionPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionPersonaDto>> Put(int id, [FromBody] DireccionPersonaDto direccionPersonaDto)
        {
            if (direccionPersonaDto == null)
            {
                return NotFound();
            }
            var direccionpersona = _mapper.Map<Direccionpersona>(direccionPersonaDto);
            _unitOfWork.Direccionpersonas.Update(direccionpersona);
            await _unitOfWork.SaveAsync();
            return direccionPersonaDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Direccionpersona>> Delete(int id)
        {
            var direccionpersona = await _unitOfWork.Direccionpersonas.GetByIdAsync(id);
            if (direccionpersona == null)
            {
                return NotFound();
            }
            _unitOfWork.Direccionpersonas.Remove(direccionpersona);
            await _unitOfWork.SaveAsync();
            return NoContent();

        }
    }
}