using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using VuexyBase.Domain.Enums.Helper;

namespace VuexyBase.Application.Application.Common.Helpers
{
    public static class UploadHelper
    {

        public static string Upload(IFormFile Photo, int FileName, IHostingEnvironment HostingEnvironment)
        {
            string folderName = System.Enum.GetName(typeof(FileName), FileName);
            string uniqueFileName = string.Empty;
            if (Photo != null)
            {
                // Ensure base images directory exists
                string baseImageFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                if (!Directory.Exists(baseImageFolder))
                    Directory.CreateDirectory(baseImageFolder);

                // Ensure specific subfolder exists
                string uploadsFolder = Path.Combine(baseImageFolder, folderName);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return $"images/{folderName}/" + uniqueFileName;
        }
    }
}
