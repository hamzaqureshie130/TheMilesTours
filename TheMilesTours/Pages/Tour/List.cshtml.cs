using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace TheMilesTours.Pages.Tour
{
    public class ListModel : PageModel
    {
        private readonly ITourService _tourService;
        public ListModel(ITourService tourService)
        {
            _tourService = tourService;
        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> Tours { get; set; } = new List<DomainLayer.TheMilesTours.Entities.Tour>();
        public async Task OnGet()
        {
            Tours = await _tourService.GetAllToursAsync();
        }
    }
}
