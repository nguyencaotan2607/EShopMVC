using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopMvcSolution.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string FileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string FileName);
        Task DeleteFileAsync(string FileName);
    }
}
