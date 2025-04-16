using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.Service
{
    public class CarService:ICarService
    {
        private readonly ICarRepository  _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;

        }

        public async Task<bool> Add(Car car)
        {
           return await _carRepository.Add(car);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carRepository.GetAll();
        }

        public async Task<Car> GetById(Guid id)
        {
           return await _carRepository.GetById(id);
        }

        public async Task<bool> Update(Car car)
        {
            return await _carRepository.Update(car);
        }
    }
}
