using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.IRepository
{
    public interface IDestinationRepository
    {
        Task<bool> Add(Destination destination);
        Task<bool> Update(Destination destination);
        Task<bool> Delete(Guid id);
        Task<Destination> GetById(Guid id);
        Task<IEnumerable<Destination>> GetAll();
    }
}
