using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Dtos.Motorcycle
{
    public class CreateMotorcycleRequestDto
    {
        public required string Identifier { get; set; }
        public required int Year { get; set; }
        public required string Model { get; set; }
        public required string Plate { get; set; }
    }
}