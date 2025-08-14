using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Dtos.Motorcycle
{
    public class UpdateMotorcycleRequestDto
    {
        public required string Plate { get; set; }
    }
}