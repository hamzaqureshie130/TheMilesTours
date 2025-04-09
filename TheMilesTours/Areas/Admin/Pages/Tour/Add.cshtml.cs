using ApplicationLayer.TheMilesTours.IService;
using ApplicationLayer.TheMilesTours.Service;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMilesTours.Helper;

namespace TheMilesTours.Areas.Admin.Pages.Tour
{
    public class AddModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IGalleryService _galleryService;
        private readonly FileUploader _fileUploader;
        public AddModel(ITourService tourService,FileUploader fileUploader, IGalleryService galleryService)
        {
            _tourService = tourService;
            _fileUploader = fileUploader;
            _galleryService = galleryService;
        }
        [BindProperty]
        public DomainLayer.TheMilesTours.Entities.Tour Tour { get; set; } = new();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Tour.CoverImageFile != null)
            {
                var uploadResult = await _fileUploader.UploadFile(Tour.CoverImageFile);
                if (uploadResult.status)
                {
                    Tour.CoverImageUrl = uploadResult.url;
                }
                else
                {
                    ModelState.AddModelError("", uploadResult.message);
                    return Page();
                }
            }
            
            var status = await _tourService.AddTourAsync(Tour);
            if (Tour.GalleryFiles != null && Tour.GalleryFiles.Any())
            {



                foreach (var galleryImage in Tour.GalleryFiles)
                {

                    var newImageResult = await _fileUploader.UploadFile(galleryImage);
                    if (newImageResult.status)
                    {
                        var galleryObject = new Gallery();
                        {
                            galleryObject.Id = Guid.NewGuid();
                            galleryObject.ImageUrl = newImageResult.url;
                            galleryObject.TourId = Tour.Id;
                        }

                        bool result = await _galleryService.AddGallery(galleryObject);
                    }

                }
            }
            if (status)
            {
                return RedirectToPage("/Tour/Plan/Add", new { tourId = Tour.Id });

            }
            return Page();
            
        }

    }
}
