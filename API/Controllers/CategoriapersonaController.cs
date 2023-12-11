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
    public class CategoriapersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoriapersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriapersonaDto>>> Get()
        {
            var Categoriapersona = await _unitOfWork.Categoriapersonas.GetAllAsync();
            return _mapper.Map<List<CategoriapersonaDto>>(Categoriapersona);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriapersonaDto>> Get(int id)
        {
            var categoriapersonas = await _unitOfWork.Categoriapersonas.GetByIdAsync(id);
            if (categoriapersonas == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoriapersonaDto>(categoriapersonas);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoriapersona>> Post(CategoriapersonaDto categoriapersonaDto)
        {
            var categoriapersonas = _mapper.Map<Categoriapersona>(categoriapersonaDto);
            _unitOfWork.Categoriapersonas.Add(categoriapersonas);
            await _unitOfWork.SaveAsync();
            if (categoriapersonas == null)
            {
                return BadRequest();
            }
            categoriapersonaDto.Id = categoriapersonas.Id;
            return CreatedAtAction(nameof(Post), new { id = categoriapersonaDto.Id }, categoriapersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriapersonaDto>> Put(int id, [FromBody] CategoriapersonaDto categoriapersonaDto)
        {
            if (categoriapersonaDto == null)
            {
                return NotFound();
            }
            var categoriapersonas = _mapper.Map<Categoriapersona>(categoriapersonaDto);
            _unitOfWork.Categoriapersonas.Update(categoriapersonas);
            await _unitOfWork.SaveAsync();
            return categoriapersonaDto;
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Categoriapersona>> Delete(int id)
        {
            var categoriapersona = await _unitOfWork.Categoriapersonas.GetByIdAsync(id);
            if(categoriapersona == null)
            {
                return NotFound();
            }
            _unitOfWork.Categoriapersonas.Remove(categoriapersona);
            await _unitOfWork.SaveAsync();
            return NoContent();

        }
    }
}

