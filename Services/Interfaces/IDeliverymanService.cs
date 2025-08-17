using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Models;

namespace Desafio_BackEnd.Services.Interfaces
{
    public interface IDeliverymanService
    {
        DeliverymanDto? GetById(Guid id);
        DeliverymanDto Create(CreateDeliverymanRequestDto deliveryman);
    }
}