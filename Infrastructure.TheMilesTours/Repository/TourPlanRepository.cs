using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using Infrastructure.TheMilesTours.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.Repository
{
    public class TourPlanRepository:ITourPlanRepository
    {
        private readonly ApplicationDbContext _context;
        public TourPlanRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddTourPlanAsync(TourPlan tourPlan)
        {
           await _context.TourPlan.AddAsync(tourPlan);
            return await _context.SaveChangesAsync() > 0;

        }

        public Task<TourPlan> GetTourPlanByIdAsync(Guid id)
        {
           var tourPlan = _context.TourPlan.FirstOrDefaultAsync(x => x.Id == id);
            if (tourPlan != null)
            {
                return tourPlan;
            }
            throw null;
        }

        public async Task<bool> UpdateTourPlanAsync(TourPlan tourPlan)
        {
            var tourPlanFromDb = await _context.TourPlan.FindAsync(tourPlan.Id);
            if (tourPlanFromDb != null)
            {
                tourPlanFromDb.Title = tourPlan.Title;
                tourPlanFromDb.Description = tourPlan.Description;
                 _context.TourPlan.Update(tourPlanFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
