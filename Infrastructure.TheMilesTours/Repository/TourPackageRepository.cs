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
    public class TourPackageRepository: ITourPackageRepository
    {
        private readonly ApplicationDbContext _context;
        public TourPackageRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddTourPackageAsync(TourPackage tourPackage)
        {
           await _context.TourPackage.AddAsync(tourPackage);
            return await _context.SaveChangesAsync() > 0;

        }

        public Task<TourPackage> GetTourPackageByIdAsync(Guid id)
        {
           var tourPackage = _context.TourPackage.FirstOrDefaultAsync(x => x.Id == id);
            if (tourPackage != null)
            {
                return tourPackage;
            }
            throw null;
        }

        public async Task<bool> UpdateTourPackageAsync(TourPackage tourPackage)
        {
            var tourPackageFromDb = await _context.TourPackage.FindAsync(tourPackage.Id);
            if (tourPackageFromDb != null)
            {
                tourPackageFromDb.Destination = tourPackage.Destination;
                tourPackageFromDb.DepartureLocation = tourPackage.DepartureLocation;
                tourPackageFromDb.ReturnLocation = tourPackage.ReturnLocation;
                tourPackageFromDb.PriceIncludes = tourPackage.PriceIncludes;
                tourPackageFromDb.PriceDoesNotInclude = tourPackage.PriceDoesNotInclude;
                tourPackageFromDb.AdditionalPrices = tourPackage.AdditionalPrices;


                _context.TourPackage.Update(tourPackageFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
