using ApplicationLayer.TheMilesTours.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMilesTours.Helper;

namespace TheMilesTours.Areas.Admin.Pages.Car
{
    public class AddModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly ICarGalleryService _carGalleryService;

        public AddModel(ICarService carService, ICarGalleryService carGalleryService)
        {
            _carService = carService;
            _carGalleryService = carGalleryService;
        }
        [BindProperty]
        public DomainLayer.TheMilesTours.Entities.Car Car { get; set; } = new();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Car.CoverImageFile != null)
            {
                var uploadResult = FileUploader.ConvertFileToBase64WithMimeType(Car.CoverImageFile);
                if (!string.IsNullOrEmpty(uploadResult))
                {
                    Car.Base64Image = uploadResult;
                }
                else
                {
                    ModelState.AddModelError("", uploadResult);
                    return Page();
                }
            }
            var status = await _carService.Add(Car);
            if (Car.GalleryFiles != null && Car.GalleryFiles.Any())
            {
                foreach (var galleryImage in Car.GalleryFiles)
                {
                    var newImageResult = FileUploader.ConvertFileToBase64WithMimeType(galleryImage);
                    if (!string.IsNullOrEmpty(newImageResult))
                    {
                        var galleryObject = new DomainLayer.TheMilesTours.Entities.CarGallery
                        {
                            Id = Guid.NewGuid(),
                            CarId = Car.Id,
                            ImageUrl = newImageResult
                        };
                        await _carGalleryService.AddGallery(galleryObject);
                    }
                }
            }
            return RedirectToPage("Index");
        }
    }
}
