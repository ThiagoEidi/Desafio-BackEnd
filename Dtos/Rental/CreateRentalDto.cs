using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Dtos.Rental
{
    public class CreateRentalDto
    {
        public Guid Deliveryman { get; set; }
        public Guid Motorcycle { get; set; }
        public Guid RentalPlan { get; set; }
        public DateTime StartDate { get; set; }
    }
}