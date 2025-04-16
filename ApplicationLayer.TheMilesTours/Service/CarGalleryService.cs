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
    public class CarGalleryService : ICarGalleryService
    {
        private ICarGalleryRepository _galleryRepository;
        public CarGalleryService(ICarGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task<bool> AddGallery(CarGallery gallery)
        {
            return await _galleryRepository.AddGallery(gallery);
        }
       
    }
}
