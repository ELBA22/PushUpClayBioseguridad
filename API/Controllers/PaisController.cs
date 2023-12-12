using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaisController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var pais = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PaisDto>>(pais);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return _mapper.Map<PaisDto>(pais);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = _mapper.Map<Pais>(paisDto);
            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();
            if (paisDto == null)
            {
                return BadRequest();
            }
            paisDto.Id = paisDto.Id;
            return CreatedAtAction(nameof(Post), new { id = paisDto.Id }, paisDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto paisDto)
        {
            if (paisDto == null)
            {
                return NotFound();
            }
            var pais = _mapper.Map<Pais>(paisDto);
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return paisDto;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pais>> Delete(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}