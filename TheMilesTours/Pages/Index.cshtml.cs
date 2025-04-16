using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IDestinationService _destinationService;
        private readonly ICarService _carService;
        public IndexModel(ITourService tourService, IDestinationService destinationService, ICarService carService)
        {
            _tourService = tourService;
            _destinationService = destinationService;
            _carService = carService;
        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> Tours { get; set; }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Destination> Destinations { get; set; }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Car> Cars { get; set; }
        public async Task OnGet()
        {
            Tours = await _tourService.GetAllToursAsync();
            Destinations = await _destinationService.GetAll();
            Cars = await _carService.GetAll();
        }
    }
}
