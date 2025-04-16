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
    class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _context;
        public GalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGallery(Gallery gallery)
        {
            await _context.Gallery.AddAsync(gallery);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGallery(Guid galleryId)
        {
            var gallery = await _context.Gallery.FindAsync(galleryId);
            if (gallery != null)
            {
                _context.Gallery.Remove(gallery);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> EditGallery(Gallery gallery)
        {
            var galleryFromDb = await _context.Gallery.FindAsync(gallery.Id);
            if (galleryFromDb != null)
            {
                galleryFromDb.ImageUrl = gallery.ImageUrl;
                _context.Gallery.Update(galleryFromDb);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Gallery>> GetAllGalleryByTourId(Guid tourId)
        {
            return await _context.Gallery
                                 .Where(x => x.TourId == tourId)
                                 .ToListAsync();
        }

    }
}
