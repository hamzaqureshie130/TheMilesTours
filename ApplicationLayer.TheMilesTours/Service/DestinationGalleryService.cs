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
    public class DestinationGalleryService : IDestinationGalleryService
    {
        private IDestinationGalleryRepository _galleryRepository;
        public DestinationGalleryService(IDestinationGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task<bool> AddGallery(DestinationGallery gallery)
        {
            return await _galleryRepository.AddGallery(gallery);
        }

        public async Task<bool> DeleteGallery(Guid galleryId)
        {
            return await _galleryRepository.DeleteGallery(galleryId);
        }

        public async Task<bool> EditGallery(DestinationGallery gallery)
        {
            return await _galleryRepository.EditGallery(gallery);
        }

       
    }
}
