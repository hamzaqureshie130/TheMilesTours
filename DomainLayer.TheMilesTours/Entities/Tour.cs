using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class Tour:BaseEntity
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal PricePerPerson { get; set; }
        public int DiscountPercentage { get; set; }
        public bool HasDiscout { get; set; }
        public string Location { get; set; }
        public string StayDuration { get; set; }
        public string ActivityType { get; set; }
        public string OverView { get; set; }
        public string TourEquipement { get; set; }
        public string TourAttraction { get; set; }
        public string GoogleMapUrl { get; set; }

        // Relationships
        public ICollection<Gallery> GalleryImages { get; set; } = new List<Gallery>();
        public ICollection<TourPlan> TourPlan { get; set; } = new List<TourPlan>();
      
      
        public TourPackage TourPackage { get; set; }
        // NotMapped
        [NotMapped]
        public IFormFile CoverImageFile { get; set; }
        [NotMapped]
        public List<IFormFile> GalleryFiles { get; set; } = new List<IFormFile>();
    }
}
