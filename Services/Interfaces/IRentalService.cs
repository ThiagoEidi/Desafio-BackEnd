using System;
using Desafio_BackEnd.Dtos.Rental;

namespace Desafio_BackEnd.Services.Interfaces
{
    public interface IRentalService
    {
        RentalDto Create(CreateRentalDto dto);
        RentalDto? GetById(Guid id);
        RentalDto Update(Guid id, DevolutionDto dto);
    }
}
