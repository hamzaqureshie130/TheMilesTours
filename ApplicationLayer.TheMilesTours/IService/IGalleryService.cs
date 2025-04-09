using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.IService
{
    public interface IGalleryService
    {
        Task<bool> AddGallery(Gallery gallery);
        Task<bool> DeleteGallery(Guid galleryId);
        Task<bool> EditGallery(Gallery gallery);
       
    }
}
