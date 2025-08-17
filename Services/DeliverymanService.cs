using System.Globalization;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Mappers;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Repositories.Interfaces;
using Desafio_BackEnd.Services.Interfaces;
namespace Desafio_BackEnd.Services
{
    public class DeliverymanService : IDeliverymanService
    {
        private readonly IDeliverymanRepository _repository;

        public DeliverymanService(IDeliverymanRepository repository)
        {
            _repository = repository;
        }
        
        public DeliverymanDto? GetById(Guid id)
        {
            var deliveryman = _repository.GetById(id);
            return deliveryman?.ToDeliverymanDto();
        }

        public DeliverymanDto Create(CreateDeliverymanRequestDto dto)
        {
            var deliverymanModel = dto.ToDeliverymanCreateDto();

            _repository.Create(deliverymanModel);

            return deliverymanModel.ToDeliverymanDto();
        }

    }
}
