using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.IService
{
    public interface ICarGalleryService
    {
        Task<bool> AddGallery(CarGallery gallery);    
    }
}
