using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Areas.Admin.Pages.Tour
{
    [Area("Admin")]
    public class IndexModel : PageModel
    {
        private readonly ITourService _tourService;
        public IndexModel(ITourService tourService)
        {
            _tourService = tourService;

        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> Tours { get; set; } 
        public async Task OnGet()
        {
            Tours = await _tourService.GetAllToursAsync();
        }
    }
}
