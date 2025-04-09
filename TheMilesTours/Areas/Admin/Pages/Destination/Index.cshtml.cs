using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Areas.Admin.Pages.Destination
{
    public class IndexModel : PageModel
    {
        private readonly IDestinationService _destinationService;
        public IndexModel(IDestinationService destinationService)
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
