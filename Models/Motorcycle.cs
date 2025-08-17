using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public class Motorcycle : ITimestamp
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
