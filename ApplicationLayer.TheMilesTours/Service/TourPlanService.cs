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
    public class TourPlanService:ITourPlanService
    {
        private readonly ITourPlanRepository _tourPlanRepository;
        public TourPlanService(ITourPlanRepository tourPlanRepository)
        {
            _tourPlanRepository = tourPlanRepository;
        }

        public Task<bool> AddTourPlanAsync(TourPlan tourPlan)
        {
            return _tourPlanRepository.AddTourPlanAsync(tourPlan);
        }

        public async Task<TourPlan> GetTourPlanByIdAsync(Guid id)
        {
            return await _tourPlanRepository.GetTourPlanByIdAsync(id);
        }

        public async Task<bool> UpdateTourPlanAsync(TourPlan touPlan)
        {
            return await _tourPlanRepository.UpdateTourPlanAsync(touPlan);
        }
    }
}
