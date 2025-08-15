using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models;


namespace Desafio_BackEnd.Interfaces
{
    public interface IMotorcycleRepository
    {
        List<Motorcycle> GetAll(string? plate);
        Motorcycle? GetById(Guid id);
        Motorcycle Create(Motorcycle motorcycle);
        Motorcycle? UpdatePlate(Guid id, string plate);
        bool Delete(Guid id);
    }
}