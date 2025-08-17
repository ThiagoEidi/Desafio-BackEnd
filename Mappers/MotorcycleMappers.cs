using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Dtos.Motorcycle;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace Desafio_BackEnd.Mappers
{
    public static class MotorcycleMappers
    {
        public static MotorcycleDto ToMotorcycleDto(this Motorcycle motorcycleModel)
        {
            return new MotorcycleDto
            {
                Id = motorcycleModel.Id,
                Identifier = motorcycleModel.Identifier,
                Year = motorcycleModel.Year,
                Model = motorcycleModel.Model,
                Plate = motorcycleModel.Plate,
                CreatedAt = motorcycleModel.CreatedAt,
                UpdatedAt = motorcycleModel.UpdatedAt
            };
        }

        public static Motorcycle ToMotorcycleCreateDto(this CreateMotorcycleRequestDto motorcycleDto)
        {
            return new Motorcycle
            {
                Identifier = motorcycleDto.Identifier,
                Year = motorcycleDto.Year,
                Model = motorcycleDto.Model,
                Plate = motorcycleDto.Plate
            
            };
        }
    }
}