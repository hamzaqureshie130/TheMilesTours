using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.TheMilesTours.Entities
{
    public class TourPackage : BaseEntity
    {
        
            public string Destination { get; set; }
            public string DepartureLocation { get; set; }
            public string ReturnLocation { get; set; }
            public string PriceIncludes { get; set; } 
            public string PriceDoesNotInclude { get; set; } 
            public string AdditionalPrices { get; set; }

            // Relationships
            public Guid TourId { get; set; }
            public Tour Tour { get; set; }


        
    }
}
