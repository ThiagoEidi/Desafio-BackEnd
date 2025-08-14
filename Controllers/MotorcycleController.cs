using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_BackEnd.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MotorcycleController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? plate)
        {
            var query = _context.Motorcycles.AsQueryable();
            if (!string.IsNullOrEmpty(plate))
            {
                query = query.Where(m => m.Plate.Contains(plate));
            }
            var motorcycles = query
                .ToList()
                .Select(m => m.ToMotorcycleDto());
            return Ok(motorcycles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var motorcycle = _context.Motorcycles.Find(id);

            if (motorcycle == null)
            {
                return NotFound();
            }
            return Ok(motorcycle.ToMotorcycleDto());
        }

        [HttpPost]
        public IActionResult Crete([FromBody] CreateMotorcycleRequestDto motorcycleDto)
        {
            var motorcycleModel = motorcycleDto.ToMotorcycleCreateDto();
            _context.Motorcycles.Add(motorcycleModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = motorcycleModel.Id }, motorcycleModel.ToMotorcycleDto());
        }

        [HttpPatch("{id}/plate")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateMotorcycleRequestDto updateDto)
        {
            var motorcycleModel = _context.Motorcycles.FirstOrDefault(x => x.Id == id);

            if (motorcycleModel == null)
            {
                return NotFound();
            }

            motorcycleModel.Plate = updateDto.Plate;

            _context.SaveChanges();

            return Ok(motorcycleModel.ToMotorcycleDto());

        }
    }
}