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
    public class DestinationRepository:IDestinationRepository
    {
        private readonly ApplicationDbContext _context;
        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Destination destination)
        {
            await _context.Destination.AddAsync(destination);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
            {
                return false;
            }
            _context.Destination.Remove(destination);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Destination>> GetAll()
        {
            return await _context.Destination.Include(x=>x.DestinationGallery).ToListAsync();
        }

        public Task<Destination> GetById(Guid id)
        {
            var destination = _context.Destination.Include(x => x.DestinationGallery).FirstOrDefaultAsync(x => x.Id == id);
            if (destination == null)
            {
                return null;
            }
            return destination;
        }

        public async Task<bool> Update(Destination destination)
        {
           var existingDestination = await _context.Destination.FindAsync(destination.Id);
            if (existingDestination == null)
            {
                return false;
            }
            existingDestination.Title = destination.Title;
            existingDestination.OverView = destination.OverView;
            if (destination.CoverImageFile != null)
            {
                existingDestination.ComverImageUrl = destination.ComverImageUrl;
            }
            _context.Destination.Update(existingDestination);
            return await _context.SaveChangesAsync() > 0; 
        }
    }
}
