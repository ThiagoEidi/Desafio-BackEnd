using System;
using System.Linq;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Interfaces;
using Desafio_BackEnd.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_BackEnd.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleRepository _repository;

        public MotorcycleController(IMotorcycleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? plate)
        {
            var motorcycles = _repository
                .GetAll(plate)
                .Select(m => m.ToMotorcycleDto());
            return Ok(motorcycles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var motorcycle = _repository.GetById(id);

            if (motorcycle == null)
                return NotFound();

            return Ok(motorcycle.ToMotorcycleDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMotorcycleRequestDto motorcycleDto)
        {
            var motorcycleModel = motorcycleDto.ToMotorcycleCreateDto();
            _repository.Create(motorcycleModel);
            return CreatedAtAction(nameof(GetById), new { id = motorcycleModel.Id }, motorcycleModel.ToMotorcycleDto());
        }

        [HttpPatch("{id}/plate")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateMotorcycleRequestDto updateDto)
        {
            var motorcycleModel = _repository.UpdatePlate(id, updateDto.Plate);

            if (motorcycleModel == null)
                return NotFound();

            return Ok(motorcycleModel.ToMotorcycleDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var deleted = _repository.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
