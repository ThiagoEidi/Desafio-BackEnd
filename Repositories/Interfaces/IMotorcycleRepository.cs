using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models;


namespace Desafio_BackEnd.Repositories.Interfaces
{
    public interface IMotorcycleRepository
    {
        Motorcycle GetById(Guid id);
        List<Motorcycle> GetAll(string? plate);
        void Create(Motorcycle moto);
        Motorcycle UpdatePlate(Guid id, string Plate);
        bool Delete(Guid id);
    }
}