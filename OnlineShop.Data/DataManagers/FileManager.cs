using Microsoft.AspNetCore.Http;
using OnlineShop.Common;

namespace OnlineShop.Data.DataManagers
{
    public class FileManager
    {
        private readonly string imageDirectoryPath;

        public FileManager(ShopConfig shopConfig)
        {
            imageDirectoryPath = shopConfig.WebRootPath;
        }

        public async Task<string> SaveFile(IFormFile file, string name)
        {
            string relativePath = Path.Combine("images", "products", name);
            string fullPath = Path.Combine(imageDirectoryPath, relativePath);
            using (Stream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return relativePath;
        }
    }
}
