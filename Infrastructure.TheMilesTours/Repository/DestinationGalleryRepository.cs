using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using Infrastructure.TheMilesTours.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.Repository
{
    class DestinationGalleryRepository : IDestinationGalleryRepository
    {
        private readonly ApplicationDbContext _context;
        public DestinationGalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGallery(DestinationGallery gallery)
        {
            await _context.DestinationGallery.AddAsync(gallery);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGallery(Guid galleryId)
        {
            var gallery = await _context.DestinationGallery.FindAsync(galleryId);
            if (gallery != null)
            {
                _context.DestinationGallery.Remove(gallery);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> EditGallery(DestinationGallery gallery)
        {
            var galleryFromDb = await _context.DestinationGallery.FindAsync(gallery.Id);
            if (galleryFromDb != null)
            {
                galleryFromDb.ImageUrl = gallery.ImageUrl;
                _context.DestinationGallery.Update(galleryFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

      

      
    }
}
