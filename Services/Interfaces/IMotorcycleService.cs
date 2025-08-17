using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Models;


namespace Desafio_BackEnd.Services.Interfaces
{
    public interface IMotorcycleService
    {
        List<MotorcycleDto> GetAll(string? plate);
        MotorcycleDto? GetById(Guid id);
        MotorcycleDto Create(CreateMotorcycleRequestDto dto);
        MotorcycleDto? UpdatePlate(Guid id, string Plate);
        bool Delete(Guid id);
    }
}