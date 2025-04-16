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
    class CarGalleryRepository : ICarGalleryRepository
    {
        private readonly ApplicationDbContext _context;
        public CarGalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGallery(CarGallery gallery)
        {
            await _context.CarGallery.AddAsync(gallery);
            return await _context.SaveChangesAsync() > 0;
        }  
    }
}
