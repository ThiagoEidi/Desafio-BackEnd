using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public class RentalPlan : ITimestamp
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int DurationDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}