using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Interfaces;
using Desafio_BackEnd.Models;


namespace Desafio_BackEnd.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApplicationDBContext _context;
        public MotorcycleRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Motorcycle> GetAll(string? plate)
        {
            IQueryable<Motorcycle> query = _context.Motorcycles;
            if (!string.IsNullOrEmpty(plate))
            {
                query = query.Where(m => m.Plate.Contains(plate));
            }
            return query.ToList();
        }

        public Motorcycle? GetById(Guid id)
        {
            return _context.Motorcycles.Find(id);
        }

        public Motorcycle Create(Motorcycle motorcycle)
        {
            _context.Motorcycles.Add(motorcycle);
            _context.SaveChanges();
            return motorcycle;
        }

        public Motorcycle? UpdatePlate(Guid id, string plate)
        {
            var motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle == null) return null;

            motorcycle.Plate = plate;
            _context.SaveChanges();
            return motorcycle;
        }

        public bool Delete(Guid id)
        {
            var motorcycle = _context.Motorcycles.Find(id);
            if (motorcycle == null) return false;

            _context.Motorcycles.Remove(motorcycle);
            _context.SaveChanges();
            return true;
        }
    }
}