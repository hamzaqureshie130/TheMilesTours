using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class Car:BaseEntity
    {
        public string Name { get; set; }
        public int RentPerDay { get; set; }
        public string Transmission { get; set; }
        public string AirCondtion { get; set; }
        public string Driver { get; set; }
        public string Fuel { get; set; }
        public string Colour { get; set; }
        public string GeneralInformation { get; set; }
        public string Base64Image { get; set; }
        // Relationships
        public ICollection<CarGallery> CarGallery { get; set; } = new List<CarGallery>();

        [NotMapped]
        public List<IFormFile> GalleryFiles { get; set; } = new List<IFormFile>();
        [NotMapped]
        public IFormFile CoverImageFile { get; set; }


    }
}
