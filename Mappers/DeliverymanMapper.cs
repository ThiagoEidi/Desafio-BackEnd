using System;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Dtos.Deliveryman;

namespace Desafio_BackEnd.Mappers
{
    public static class DeliverymanMappers
    {
        public static DeliverymanDto ToDeliverymanDto(this Deliveryman deliveryman)
        {
            return new DeliverymanDto
            {
                Id = deliveryman.Id,
                Identifier = deliveryman.Identifier,
                Name = deliveryman.Name,
                Username = deliveryman.Username,
                Cnpj = deliveryman.CNPJ,
                BirthDate = deliveryman.BirthDate,
                CreatedAt = deliveryman.CreatedAt,
                UpdatedAt = deliveryman.UpdatedAt,
            };
        }

        public static Deliveryman ToDeliverymanCreateDto(this CreateDeliverymanRequestDto deliverymanDto)
        {
            return new Deliveryman
            {
                Identifier = deliverymanDto.Identifier,
                Name = deliverymanDto.Name,
                CNPJ = deliverymanDto.CNPJ,
                BirthDate = deliverymanDto.BirthDate,
                CNH = deliverymanDto.CNH,
                CNHType = deliverymanDto.CNHType,
                Username = deliverymanDto.Username,
                Password = deliverymanDto.Password
            };
        }

    }
}
