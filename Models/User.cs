using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public abstract class User : Timestamp
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public EnumUserRole Role { get; set; }
    }
}