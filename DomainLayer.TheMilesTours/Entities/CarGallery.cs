using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
   public class CarGallery
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
