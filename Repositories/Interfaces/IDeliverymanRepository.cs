using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Models;

namespace Desafio_BackEnd.Repositories.Interfaces
{
    public interface IDeliverymanRepository
    {
        Deliveryman? GetById(Guid id);
        void Create(Deliveryman deliveryman);
    }
}