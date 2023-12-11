using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using iText.Html2pdf.Css.Apply.Impl;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContactoPersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPersonaDto>>> Get()
        {
            var contactopersona = await _unitOfWork.Ciudades.GetAllAsync();
            return _mapper.Map<List<ContactoPersonaDto>>(contactopersona);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
        {
            var contactopersonas = await _unitOfWork.Contactopersonas.GetByIdAsync(id);
            if (contactopersonas == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactoPersonaDto>(contactopersonas);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Post(ContactoPersonaDto contactoPersonaDto)
        {
            var contactopersona = _mapper.Map<Contactopersona>(contactoPersonaDto);
            _unitOfWork.Contactopersonas.Add(contactopersona);
            await _unitOfWork.SaveAsync();
            if (contactopersona == null)
            {
                return BadRequest();
            }
            contactoPersonaDto.Id = contactopersona.Id;
            return CreatedAtAction(nameof(Post), new { id = contactoPersonaDto.Id }, contactoPersonaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto contactoPersonaDto)
        {
            if (contactoPersonaDto == null)
            {
                return NotFound();
            }
            var contactopersonas = _mapper.Map<Contactopersona>(contactoPersonaDto);
            _unitOfWork.Contactopersonas.Update(contactopersonas);
            await _unitOfWork.SaveAsync();
            return contactoPersonaDto;
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contactopersona>> Delete(int id)
        {
            var contactopersona = await _unitOfWork.Contactopersonas.GetByIdAsync(id);
            if (contactopersona == null)
            {
                return NotFound();
            }
            _unitOfWork.Contactopersonas.Remove(contactopersona);
            await _unitOfWork.SaveAsync();
            return NoContent();

        }





    }
}