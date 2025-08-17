using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Repositories.Interfaces;
using Desafio_BackEnd.Models;

namespace Desafio_BackEnd.Repositories
{
    public class DeliverymanRepository : IDeliverymanRepository
    {
        private readonly ApplicationDBContext _context;

        public DeliverymanRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Deliveryman? GetById(Guid id)
        {
            return _context.Deliverymen.Find(id);
        }
        public void Create(Deliveryman deliveryman)
        {
            deliveryman.Id = Guid.NewGuid();
            _context.Deliverymen.Add(deliveryman);
            _context.SaveChanges();
        }
    }
}