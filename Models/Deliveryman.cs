using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public class Deliveryman : User
    {
        public required string Identifier { get; set; }
        public required string Name { get; set; }
        public required string CNPJ { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string CNH { get; set; }
        public required EnumCNHType CNHType { get; set; } 
    }
}