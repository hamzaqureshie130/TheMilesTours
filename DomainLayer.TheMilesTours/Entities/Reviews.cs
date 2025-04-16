using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class Reviews:BaseEntity
    {
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
