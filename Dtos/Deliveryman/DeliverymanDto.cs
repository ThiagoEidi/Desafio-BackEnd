using System;
using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Dtos.Deliveryman
{
    public class DeliverymanDto
    {
        public Guid Id { get; set; }
        public required string Identifier { get; set; }
        public string Name { get; set; }
        public string Username { get; set; } 
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public EnumCNHType CNHType { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
