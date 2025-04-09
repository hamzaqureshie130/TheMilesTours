using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMilesTours.DTO;

namespace TheMilesTours.Pages.Tour
{
    public class DetailModel : PageModel
    {
        private readonly ITourService _tourService;
        public DetailModel(ITourService tourService)
        {
            _tourService = tourService;
        }
        public DomainLayer.TheMilesTours.Entities.Tour Tour { get; set; }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> TourList { get; set; }
        [BindProperty]
        public BookingDTO Booking { get; set; } = new();
        public async Task OnGet(Guid id)
        {
            Tour = await _tourService.GetTourByIdAsync(id);
            TourList = await _tourService.GetAllToursAsync();
        }
    }
}
