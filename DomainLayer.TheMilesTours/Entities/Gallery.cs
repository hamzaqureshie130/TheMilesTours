using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class Gallery
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
