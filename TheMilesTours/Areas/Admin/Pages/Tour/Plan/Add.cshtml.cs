using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TheMilesTours.Areas.Admin.Pages.Tour.Plan
{
    public class AddModel : PageModel
    {
        private readonly ITourPlanService _tourService;

        public AddModel(ITourPlanService tourPlanService)
        {
            _tourService = tourPlanService;
        }

        [BindProperty]
        public List<TourPlan> TourPlans { get; set; } = new();

        [BindProperty]
        public Guid TourId { get; set; }

        public void OnGet(Guid tourId)
        {
            TourId = tourId;
            // Start with one empty day
            TourPlans.Add(new TourPlan { DayNumber = 1 });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Assign TourId to all plans
            foreach (var plan in TourPlans)
            {
                plan.TourId = TourId;
                await _tourService.AddTourPlanAsync(plan);
            }

            return RedirectToPage("/Tour/Package/Add", new { TourId = TourId });
        }
    }
}