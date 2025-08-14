namespace Desafio_BackEnd.Models
{
    public class Motorcycle
    {
        public Guid Id { get; set; }
        public required string Identifier { get; set; } 
        public required int Year { get; set; }
        public required string Model { get; set; } 
        public required string Plate { get; set; }
    }
}
