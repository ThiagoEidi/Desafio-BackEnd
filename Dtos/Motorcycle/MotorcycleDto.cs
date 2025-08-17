using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Dtos.Motorcycle
{
    public class MotorcycleDto
    {
        public Guid Id { get; set; }
        public required string Identifier { get; set; }
        public required int Year { get; set; }
        public required string Model { get; set; }
        public required string Plate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}