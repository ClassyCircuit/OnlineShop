using Microsoft.AspNetCore.Http;
using OnlineShop.Business.Exceptions;
using OnlineShop.Data.DataManagers;

namespace OnlineShop.Business.Services
{
    public class ImageService
    {
        private readonly FileManager _fileManager;

        public ImageService(FileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            if (image.Length <= 0)
            {
                throw new InvalidFileException();
            }

            var fileName = $"{Guid.NewGuid()}.jpg";
            var fullFilePath = await _fileManager.SaveFile(image, fileName);

            return fullFilePath;
        }
    }
}
