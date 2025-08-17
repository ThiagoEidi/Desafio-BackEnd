using Microsoft.AspNetCore.Mvc;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_BackEnd.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _service;

        public MotorcycleController(IMotorcycleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll([FromQuery] string? plate)
        {
            var motorcycles = _service.GetAll(plate);
            return Ok(motorcycles);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var motorcycle = _service.GetById(id);

            if (motorcycle == null)
                return NotFound();

            return Ok(motorcycle);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateMotorcycleRequestDto motorcycleDto)
        {
            var motorcycle = _service.Create(motorcycleDto);
            return CreatedAtAction(nameof(GetById), new { id = motorcycle.Id }, motorcycle);
        }

        [HttpPatch("{id}/plate")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateMotorcycleRequestDto updateDto)
        {
            var motorcycle = _service.UpdatePlate(id, updateDto.Plate);

            if (motorcycle == null)
                return NotFound();

            return Ok(motorcycle);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var deleted = _service.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
