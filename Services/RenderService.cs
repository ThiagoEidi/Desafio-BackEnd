using System;
using Desafio_BackEnd.Dtos.Rental;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Repositories.Interfaces;
using Desafio_BackEnd.Mappers;
using Desafio_BackEnd.Services.Interfaces;

namespace Desafio_BackEnd.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public RentalDto Create(CreateRentalDto dto)
        {
            var rental = dto.ToRental();   
            rental.Id = Guid.NewGuid();
            rental.ExpectedFinish = rental.StartDate.AddDays(7);
            rental.CreatedAt = DateTime.UtcNow;
            rental.UpdatedAt = DateTime.UtcNow;

            var created = _repository.Create(rental);
            return created.ToRentalDto();  
        }

        public RentalDto? GetById(Guid id)
        {
            var rental = _repository.GetById(id);
            if (rental == null) return null;

            return rental.ToRentalDto();  
        }

        public RentalDto Update(Guid id, DevolutionDto dto)
        {
            var rental = _repository.GetById(id);
            if (rental == null)
                throw new Exception("Rental not found");

            rental.EndDate = dto.DevolutionDate.Date;
            rental.UpdatedAt = DateTime.UtcNow;

            var updated = _repository.Update(rental);
            return updated.ToRentalDto();  // usa o mapper
        }
    }
}
