using ApplicationLayer.TheMilesTours.IService;
using ApplicationLayer.TheMilesTours.Service;
using DomainLayer.TheMilesTours.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheMilesTours.Helper;

namespace TheMilesTours.Areas.Admin.Pages.Destination
{
    public class AddModel : PageModel
    {
        private readonly IDestinationService _destinationService;
              private readonly FileUploader _fileUploader;
        private readonly IDestinationGalleryService _galleryService;
        public AddModel(IDestinationService destinationService, FileUploader fileUploader, IDestinationGalleryService galleryService)
        {
            _destinationService = destinationService;
            _fileUploader = fileUploader;
            _galleryService = galleryService;
        }
        [BindProperty]
        public DomainLayer.TheMilesTours.Entities.Destination Destination { get; set; } = new();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Destination.CoverImageFile != null)
            {
                var uploadResult = await _fileUploader.UploadFile(Destination.CoverImageFile);
                if (uploadResult.status)
                {
                    Destination.ComverImageUrl = uploadResult.url;
                }
                else
                {
                    ModelState.AddModelError("", uploadResult.message);
                    return Page();
                }
            }

            var status = await _destinationService.Add(Destination);
            if (Destination.GalleryFiles != null && Destination.GalleryFiles.Any())
            {



                foreach (var galleryImage in Destination.GalleryFiles)
                {

                    var newImageResult = await _fileUploader.UploadFile(galleryImage);
                    if (newImageResult.status)
                    {
                        var galleryObject = new DestinationGallery();
                        {
                            galleryObject.Id = Guid.NewGuid();
                            galleryObject.ImageUrl = newImageResult.url;
                            galleryObject.DestinationId = Destination.Id;
                        }

                        bool result = await _galleryService.AddGallery(galleryObject);
                    }

                }
            }
            if (status)
            {
                return RedirectToPage("/Destination/Index");

            }
            return Page();

        }
    }
}
