using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace EShopMvcSolution.Application.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public async Task DeleteFileAsync(string FileName) 
        {
            var FilePath = Path.Combine(_userContentFolder, FileName);
            if (File.Exists(FilePath))
            {
                await Task.Run(() => File.Delete(FilePath));
            }
        }

        public string GetFileUrl(string FileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{FileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string FileName)
        {
            var filepath = Path.Combine(_userContentFolder, FileName);
            using var output = new FileStream(FileName, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
