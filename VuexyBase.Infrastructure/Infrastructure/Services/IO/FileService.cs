using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using VuexyBase.Application.Application.Contracts.Infrastructure.IO;
using VuexyBase.Domain.Enums.IO;

namespace VuexyBase.Infrastructure.Infrastructure.Services.IO
{
    public class FileService : IFileService
    {
        public static string RootPath { get; set; } // Optional custom path, please create http request to your target project to get the path

        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
            RootPath = _env.WebRootPath;
        }
        public (string path, bool? isValid) UploadFile(IFormFile file, bool isValid, FolderType folderType, SubFolderType subFolderType)
        {
            if (isValid && !ValidateFile(file, 5, folderType))
            {
                return (string.Empty, false);
            }

            var folderName = folderType.ToString();

            var subFolderName = subFolderType.ToString();

            string uploadsFolder = $"{RootPath}/Uploads/{folderName}/{subFolderName}";

            Directory.CreateDirectory(uploadsFolder); // Ensures the directory exists

            string fileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";

            string filePath = $"{uploadsFolder}/{fileName}";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return ($"{folderName}/{subFolderName}/{fileName}", null);
        }

        public bool ValidateFile(IFormFile file, int maxFileSizeMB, FolderType folderType)
        {
            if (file == null || file.Length == 0)
                return false;

            long maxFileSizeBytes = maxFileSizeMB * 1024 * 1024;

            if (file.Length > maxFileSizeBytes)
                return false;

            var fileExtension = Path.GetExtension(file.FileName)?.ToLower();

            var allowedFileTypes = folderType switch
            {
                FolderType.Images => new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" },
                FolderType.Videos => new List<string> { ".mp4", ".avi", ".mov", ".mkv", ".wmv" },
                FolderType.Audios => new List<string> { ".mp3", ".wav", ".aac", ".flac" },
                FolderType.Documents => new List<string> { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt" },
                _ => new List<string>() // Empty list for "Other" or undefined cases
            };

            if (!allowedFileTypes.Contains(fileExtension!))
                return false;

            return true;
        }


    }
}
