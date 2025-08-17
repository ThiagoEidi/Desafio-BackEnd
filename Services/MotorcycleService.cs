using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Mappers;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Repositories.Interfaces;
using Desafio_BackEnd.Services.Interfaces;

namespace Desafio_BackEnd.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _repository;

        public MotorcycleService(IMotorcycleRepository repository)
        {
            _repository = repository;
        }

        public List<MotorcycleDto> GetAll(string? plate = null)
        {
            return _repository.GetAll(plate).Select(m => m.ToMotorcycleDto()).ToList();;
        }

        public MotorcycleDto? GetById(Guid id)
        {
            var moto = _repository.GetById(id);
            return moto?.ToMotorcycleDto();
        }

        public MotorcycleDto Create(CreateMotorcycleRequestDto dto)
        {
            var motoModel = dto.ToMotorcycleCreateDto();
            _repository.Create(motoModel);
            return motoModel.ToMotorcycleDto();
        }

        public MotorcycleDto? UpdatePlate(Guid id, string newPlate)
        {
            var moto = _repository.UpdatePlate(id, newPlate);
            return moto?.ToMotorcycleDto();
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}