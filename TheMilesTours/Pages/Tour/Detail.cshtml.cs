using ApplicationLayer.TheMilesTours.IService;
using ApplicationLayer.TheMilesTours.Service;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMilesTours.DTO;

namespace TheMilesTours.Pages.Tour
{
    public class DetailModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IReviewsService _reviewsService;
        public DetailModel(ITourService tourService, IReviewsService reviewsService)
        {
            _tourService = tourService;
            _reviewsService = reviewsService;
        }
        public DomainLayer.TheMilesTours.Entities.Tour Tour { get; set; }
        public IEnumerable<DomainLayer.TheMilesTours.Entities.Tour> TourList { get; set; }
        [BindProperty]
        public DomainLayer.TheMilesTours.Entities.Reviews Reviews { get; set; }

        public async Task OnGet(Guid id)
        {
            Tour = await _tourService.GetTourByIdAsync(id);
            TourList = await _tourService.GetAllToursAsync();
        }
        public async Task<JsonResult> OnPostAddReview()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "Invalid data" });
            }
            await _reviewsService.AddReviews(Reviews);

            return new JsonResult(new { success = true });
        }
    }
}
