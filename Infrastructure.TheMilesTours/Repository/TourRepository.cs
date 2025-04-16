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
    public class TourRepository:ITourRepository
    {
        private readonly ApplicationDbContext _context;
        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTourAsync(Tour tour)
        {
            await _context.AddAsync(tour);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var tour = await _context.Tour.FindAsync(id);
            if (tour != null)
            {
                _context.Tour.Remove(tour);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
           return await _context.Tour.AsNoTracking().ToListAsync();
        }

        public async Task<Tour> GetTourByIdAsync(Guid id)
        {
            var tour = await _context.Tour.Include(x => x.TourPlan).Include(x=>x.TourPackage).Include(x=>x.Reviews).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (tour != null)
            {
                return tour;
            }
            throw null;
        }

        public async Task<bool> UpdateTourAsync(Tour tour)
        {
          var tourFromDb = await _context.Tour.FindAsync(tour.Id);
            if (tourFromDb != null)
            {
                tourFromDb.Title = tour.Title;
               
                tourFromDb.PricePerPerson = tour.PricePerPerson;
                tourFromDb.DiscountPercentage = tour.DiscountPercentage;
                tourFromDb.HasDiscout = tour.HasDiscout;
                tourFromDb.Location = tour.Location;
                tourFromDb.StayDuration = tour.StayDuration;
                tourFromDb.ActivityType = tour.ActivityType;
                tourFromDb.OverView = tour.OverView;
                tourFromDb.TourEquipement = tour.TourEquipement;
                tourFromDb.TourAttraction = tour.TourAttraction;
                if (tour.CoverImageFile != null)
                {
                    tourFromDb.CoverImageFile = tour.CoverImageFile;
                }
                _context.Tour.Update(tourFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
