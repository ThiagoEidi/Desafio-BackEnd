using Microsoft.AspNetCore.Mvc;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_BackEnd.Controllers
{
    [Route("api/deliveryman")]
    [ApiController]
    public class DeliverymanController : ControllerBase
    {
        private readonly IDeliverymanService _service;

        public DeliverymanController(IDeliverymanService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var deliveryman = _service.GetById(id);

            if (deliveryman == null)
                return NotFound();

            return Ok(deliveryman);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDeliverymanRequestDto deliverymanDto)
        {
            var deliveryman = _service.Create(deliverymanDto);
            return CreatedAtAction(nameof(GetById), new { id = deliveryman.Id }, deliveryman);
        }
    }
}
