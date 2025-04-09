using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.IRepository
{
    public interface IDestinationGalleryRepository
    {
        Task<bool> AddGallery(DestinationGallery gallery);
        Task<bool> DeleteGallery(Guid galleryId);
        Task<bool> EditGallery(DestinationGallery gallery);
    }
}
