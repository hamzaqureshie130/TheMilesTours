using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.IRepository
{
    public interface ITourRepository
    {
        Task<bool> AddTourAsync(Tour tour);
        Task<bool> UpdateTourAsync(Tour tour);
        Task<bool> DeleteTourAsync(Guid id);
        Task<Tour> GetTourByIdAsync(Guid id);
        Task<IEnumerable<Tour>> GetAllToursAsync();
    }
}
