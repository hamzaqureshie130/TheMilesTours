using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.IService
{
    public interface ICarService
    {
        Task<bool> Add(Car car);
        
        Task<bool> Update(Car car);
        Task<bool> Delete(Guid id);
        Task<Car> GetById(Guid id);
        Task<IEnumerable<Car>> GetAll();
    }
}
