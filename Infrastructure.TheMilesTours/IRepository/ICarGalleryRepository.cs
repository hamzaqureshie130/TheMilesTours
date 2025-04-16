using DomainLayer.TheMilesTours.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.IRepository
{
    public interface ICarGalleryRepository
    {
        Task<bool> AddGallery(CarGallery gallery);
    }
}
