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
    public class TourService:ITourService
    {
        private readonly ITourRepository _tourRepository;
        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;

        }

        public async Task<bool> AddTourAsync(Tour tour)
        {
           return await _tourRepository.AddTourAsync(tour);
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            return await _tourRepository.DeleteTourAsync(id);
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            return await _tourRepository.GetAllToursAsync();
        }

        public async Task<Tour> GetTourByIdAsync(Guid id)
        {
         return await _tourRepository.GetTourByIdAsync(id); 
        }

        public async Task<bool> UpdateTourAsync(Tour tour)
        {
            return await _tourRepository.UpdateTourAsync(tour);
        }
    }
}
