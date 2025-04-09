using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class TourPlan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int DayNumber { get; set; }

        // Foreign Key
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
