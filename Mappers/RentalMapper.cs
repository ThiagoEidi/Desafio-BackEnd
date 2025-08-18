using System;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Dtos.Rental;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Repositories;

namespace Desafio_BackEnd.Mappers
{
    public static class RentalMapper
    {        
        public static RentalDto ToRentalDto(this Rental rental)
        {
            return new RentalDto
            {
                Id = rental.Id,
                Deliveryman = rental.Deliveryman,
                Motorcycle = rental.Motorcycle,
                RentalPlan = rental.RentalPlan,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                ExpectedFinish = rental.ExpectedFinish,
            };
        }

        public static Rental ToRental(this CreateRentalDto rentalDto)
        {
            return new Rental
            {
                Deliveryman = rentalDto.Deliveryman,
                Motorcycle = rentalDto.Motorcycle,
                RentalPlan = rentalDto.RentalPlan,
                StartDate = rentalDto.StartDate,
            };
        }
    }
}