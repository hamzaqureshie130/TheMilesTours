using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Pages.Car
{
    public class CarDetailModel(ICarService carService) : PageModel
    {
        private readonly ICarService _carService = carService;

        public DomainLayer.TheMilesTours.Entities.Car Car { get; set; }

        public async Task OnGet(Guid id)
        {
            Car = await _carService.GetById(id);
        }
    }
}
