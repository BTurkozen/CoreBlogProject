using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Interfaces
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImages(IFormFile image);
        bool DeleteImage(string image);
    }
}
