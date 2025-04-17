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
        private readonly FileUploader _fileUploader;

        public AddModel(ICarService carService, ICarGalleryService carGalleryService, FileUploader fileUploader)
        {
            _carService = carService;
            _carGalleryService = carGalleryService;
            _fileUploader = fileUploader;
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
                var uploadResult = await _fileUploader.UploadFile(Car.CoverImageFile);
                if (uploadResult.status)
                {
                    Car.Base64Image = uploadResult.url ;
                }
                else
                {
                    ModelState.AddModelError("", uploadResult.url);
                    return Page();
                }
            }
            var status = await _carService.Add(Car);
            if (Car.GalleryFiles != null && Car.GalleryFiles.Any())
            {
                foreach (var galleryImage in Car.GalleryFiles)
                {
                    var newImageResult = await _fileUploader.UploadFile(galleryImage);
                    if (newImageResult.status)
                    {
                        var galleryObject = new DomainLayer.TheMilesTours.Entities.CarGallery
                        {
                            Id = Guid.NewGuid(),
                            CarId = Car.Id,
                            ImageUrl = newImageResult.url
                        };
                        await _carGalleryService.AddGallery(galleryObject);
                    }
                }
            }
            return RedirectToPage("Index");
        }
    }
}
