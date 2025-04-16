using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Areas.Admin.Pages.Car
{
    public class IndexModel : PageModel
    {
        private readonly ICarService _carService;
        public IndexModel(ICarService carService)
        {
            _carService = carService;
        }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Car> Cars { get; set; } = new List<DomainLayer.TheMilesTours.Entities.Car>();
        public async Task OnGet()
        {
            Cars = await _carService.GetAll();
        }
    }
}
