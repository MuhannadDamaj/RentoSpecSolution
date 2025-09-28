using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class UploadImageService
    {
        private readonly IWebHostEnvironment _env;

        public UploadImageService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/{file.FileName}";
        }
    }
}
