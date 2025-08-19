using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models.Utils;

namespace Desafio_BackEnd.Models
{
    public class Rental : Timestamp
    {
        public Guid Id { get; set; }
        public required Guid Deliveryman { get; set; }
        public required Guid Motorcycle { get; set; }
        public required Guid RentalPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedFinish { get; set; }
        public Decimal Value { get; set; }
    }
}