using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Repositories.Interfaces;
using Desafio_BackEnd.Models;


namespace Desafio_BackEnd.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly ApplicationDBContext _context;

        public MotorcycleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Motorcycle> GetAll(string? plate = null)
        {
            IQueryable<Motorcycle> query = _context.Motorcycles;
            if (!string.IsNullOrEmpty(plate))
            {
                query = query.Where(m => m.Plate == plate);
            }
            return query.ToList();
        }

        public Motorcycle? GetById(Guid id)
        {
            return _context.Motorcycles.Find(id);
        }

        public void Create(Motorcycle moto)
        {
            moto.Id = Guid.NewGuid();
            _context.Motorcycles.Add(moto);
            _context.SaveChanges();
        }

        public Motorcycle? UpdatePlate(Guid id, string newPlate)
        {
            var moto = _context.Motorcycles.Find(id);
            if (moto == null) return null;
            moto.Plate = newPlate;
            _context.SaveChanges();
            return moto;
        }

        public bool Delete(Guid id)
        {
            var moto = _context.Motorcycles.Find(id);
            if (moto == null) return false;
            _context.Motorcycles.Remove(moto);
            _context.SaveChanges();
            return true;
        }
    }
}