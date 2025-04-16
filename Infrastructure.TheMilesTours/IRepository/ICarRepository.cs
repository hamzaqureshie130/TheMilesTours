using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.IRepository
{
    public interface ICarRepository
    {
        Task<bool> Add(Car car);

        Task<bool> Update(Car car);
        Task<bool> Delete(Guid id);
        Task<Car> GetById(Guid id);
        Task<IEnumerable<Car>> GetAll();
    }
}
