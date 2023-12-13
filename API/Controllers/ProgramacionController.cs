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
    public class ProgramacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProgramacionDto>>> Get()
        {
            var programacion = await _unitOfWork.Programaciones.GetAllAsync();
            return _mapper.Map<List<ProgramacionDto>>(programacion);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProgramacionDto>> Get(int id)
        {
            var programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
            if (programacion == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProgramacionDto>(programacion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>>Post(ProgramacionDto programacionDto)
        {
            var programacion = _mapper.Map<Programacion>(programacionDto);
            _unitOfWork.Programaciones.Add(programacion);
            await _unitOfWork.SaveAsync();
            if(programacion == null)
            {
                return BadRequest();
            }
            programacionDto.Id = programacionDto.Id;
            return CreatedAtAction(nameof(Post), new {id = programacionDto.Id}, programacionDto);
        }


    }
}