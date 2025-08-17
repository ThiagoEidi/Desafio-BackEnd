using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public abstract class User : ITimestamp
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}