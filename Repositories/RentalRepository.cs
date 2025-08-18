using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Repositories.Interfaces;

namespace Desafio_BackEnd.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDBContext _context;

        public RentalRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Rental Create(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return rental;
        }

        public Rental? GetById(Guid id)
        {
            return _context.Rentals.FirstOrDefault(r => r.Id == id);
        }

        public Rental Update(Rental rental)
        {
            _context.Rentals.Update(rental);
            _context.SaveChanges();
            return rental;
        }
    }
}