
using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheMilesTours.Areas.Admin.Pages.Tour.Package
{
    public class AddModel : PageModel
    {
        private readonly ITourPackageService _tourPackageService;
        public AddModel(ITourPackageService tourPackageService)
        {
            _tourPackageService = tourPackageService;
        }
        [BindProperty]
        public Guid TourId { get; set; }
        [BindProperty]
        public DomainLayer.TheMilesTours.Entities.TourPackage TourPackage { get; set; } = new();

        public void OnGet(Guid tourId)
        {
            TourId = tourId;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TourPackage.TourId = TourId;
            var status = await _tourPackageService.AddTourPackageAsync(TourPackage);
            if (status)
            {
                return RedirectToPage("/Tour/Index");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong");
                return Page();
            }
        }
    }
}
