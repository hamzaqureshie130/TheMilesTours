using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class Destination:BaseEntity
    {
        public string Title { get; set; }
        public string OverView { get; set; }
        public string ComverImageUrl { get; set; }
        // Relationships
        public ICollection<DestinationGallery> DestinationGallery { get; set; } = new List<DestinationGallery>();

        [NotMapped]
        public IFormFile CoverImageFile { get; set; }
        [NotMapped]
        public List<IFormFile> GalleryFiles { get; set; } = new List<IFormFile>();

    }
}
