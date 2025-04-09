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
    public class TourPackageService: ITourPackageService
    {
        private readonly ITourPackageRepository _tourPackageRepository;
        public TourPackageService(ITourPackageRepository tourPackageRepository)
        {
            _tourPackageRepository = tourPackageRepository;
        }

        public async Task<bool> AddTourPackageAsync(TourPackage tourPackage)
        {
            return await _tourPackageRepository.AddTourPackageAsync(tourPackage);
        }

        public async Task<TourPackage> GetTourPackageByIdAsync(Guid id)
        {
            return await _tourPackageRepository.GetTourPackageByIdAsync(id);
        }

        public async Task<bool> UpdateTourPackageAsync(TourPackage tourPackage)
        {
            return await _tourPackageRepository.UpdateTourPackageAsync(tourPackage);  
        }
    }
}
