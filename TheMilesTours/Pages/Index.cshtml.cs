using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IDestinationService _destinationService;

        public IndexModel(ITourService tourService, IDestinationService destinationService)
        {
            _tourService = tourService;
            _destinationService = destinationService;
        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> Tours { get; set; }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Destination> Destinations { get; set; }
        public async Task OnGet()
        {
            Tours = await _tourService.GetAllToursAsync();
            Destinations = await _destinationService.GetAll();
        }
    }
}
