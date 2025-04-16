using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using Infrastructure.TheMilesTours.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.Repository
{
    public class CarRepository:ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Car car)
        {
            await _context.Car.AddAsync(car);
            return await _context.SaveChangesAsync() > 0;   
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
           return await _context.Car.Include(x=>x.CarGallery).ToListAsync();
        }

        public Task<Car> GetById(Guid id)
        {
            var car = _context.Car.Include(x => x.CarGallery).FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return null;
            }
            return car;
        }

        public Task<bool> Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
