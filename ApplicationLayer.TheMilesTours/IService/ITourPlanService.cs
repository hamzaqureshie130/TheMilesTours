using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.IService
{
    public interface ITourPlanService
    {
        Task<bool> AddTourPlanAsync(TourPlan tourPlan);
        Task<bool> UpdateTourPlanAsync(TourPlan tourPlan);
        Task<TourPlan> GetTourPlanByIdAsync(Guid id);
    }
}
