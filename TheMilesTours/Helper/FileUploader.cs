namespace TheMilesTours.Helper
{
    public class FileUploader
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<(bool status, string message, string url)> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return (false, "Please select a file to upload.", "");
            }

            try
            {
                var uploadsDirectory = Path.Combine(_environment.WebRootPath, "assets/documents");

                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                var uniqueFileName = $"{Guid.NewGuid().ToString()}_{DateTime.Now:yyyyMMddHHmmssfff}_{file.FileName}";
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return (true, "File uploaded successfully!", $"assets/documents/{uniqueFileName}");
            }
            catch (Exception ex)
            {
                return (false, $"Error uploading file: {ex.Message}", "");
            }
        }

        public async Task<(bool status, string message, string url)> UploadVideo(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return (false, "Please select a file to upload.", "");
            }

            try
            {
                var uploadsDirectory = Path.Combine(_environment.WebRootPath, "assets/videos");

                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                var uniqueFileName = $"{Guid.NewGuid().ToString()}_{DateTime.Now:yyyyMMddHHmmssfff}_{file.FileName}";
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return (true, "File uploaded successfully!", $"assets/videos/{uniqueFileName}");
            }
            catch (Exception ex)
            {
                return (false, $"Error uploading file: {ex.Message}", "");
            }
        }
        public static string ConvertFileToBase64WithMimeType(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Copy file data to memory stream
                file.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                // Determine MIME type
                string mimeType = file.ContentType; // Get MIME type from IFormFile

                // Combine MIME type and base64 string
                string base64String = Convert.ToBase64String(fileBytes);
                return $"data:{mimeType};base64,{base64String}";
            }
        }
    }
}
