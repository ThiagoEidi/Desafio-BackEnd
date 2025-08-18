using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Dtos.Rental
{
    public class RentalDto
    {
        public Guid Id { get; set; }
        public required Guid Deliveryman { get; set; }
        public required Guid Motorcycle { get; set; }
        public required Guid RentalPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedFinish { get; set; }
        public decimal Value { get; set; }

    }
}