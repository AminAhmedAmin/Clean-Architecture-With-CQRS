using Microsoft.AspNetCore.Http;
using VuexyBase.Domain.Enums.IO;

namespace VuexyBase.Application.Application.Contracts.Infrastructure.IO
{
    public interface IFileService
    {
        (string path, bool? isValid) UploadFile(IFormFile file, bool isValid = true, FolderType folderType = FolderType.Images, SubFolderType subFolderType = SubFolderType.General);

        bool ValidateFile(IFormFile file, int maxFileSizeMB, FolderType folderType);
    }
}
