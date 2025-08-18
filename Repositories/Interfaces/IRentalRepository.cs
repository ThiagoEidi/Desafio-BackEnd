using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models;

namespace Desafio_BackEnd.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        Rental Create(Rental rental);
        Rental? GetById(Guid id);
        Rental Update(Rental rental);
    }

}