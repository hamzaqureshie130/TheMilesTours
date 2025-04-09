using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.IService
{
    public interface ITourPackageService
    {
        Task<bool> AddTourPackageAsync(TourPackage tourPackage);
        Task<bool> UpdateTourPackageAsync(TourPackage tourPackage);
        Task<TourPackage> GetTourPackageByIdAsync(Guid id);
    }
}
