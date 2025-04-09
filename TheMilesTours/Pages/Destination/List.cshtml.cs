using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Pages.Destination
{
    public class ListModel : PageModel
    {
        private readonly IDestinationService _destinationService;
        public ListModel(IDestinationService destinationService)
        {
            _destinationService = destinationService;

        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Destination> Destinations { get; set; }
        public async Task OnGet()
        {
            Destinations = await _destinationService.GetAll();
        }
    }
}
