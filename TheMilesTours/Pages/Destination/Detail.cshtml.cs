using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Pages.Destination
{
    public class DetailModel : PageModel
    {
        private readonly IDestinationService _destinationService;
        public DetailModel(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public DomainLayer.TheMilesTours.Entities.Destination Destination { get; set; } = new();

        public async Task OnGet(Guid id)
        {
            Destination = await _destinationService.GetById(id);
        }
    }
}
