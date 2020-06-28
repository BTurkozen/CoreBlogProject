using CoreBlogProject.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Repositories
{
    public class FileManager : IFileManager
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileManager(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

        }

        public FileStream ImageStream(string image)
        {
            string imagePath = _hostEnvironment.WebRootPath;
            return new FileStream(Path.Combine(imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImages(IFormFile image)
        {
            string imagePath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(image.FileName);
            string fileName = Guid.NewGuid() + extension;
            string path = Path.Combine(imagePath + "/Images/" + fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public bool DeleteImage(string image)
        {
            string imagePath = _hostEnvironment.WebRootPath;
            if (!string.IsNullOrEmpty(image))
            {
                var file = Path.Combine(imagePath + "/Images/" + image);
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            return true;
        }


        #region Raw Codding
        //private string _imagePath;

        //public FileManager(IConfiguration config)
        //{
        //    _imagePath = config["Path:Images"];
        //}

        //public FileStream ImageStream(string image)
        //{
        //    return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        //}

        //public async Task<string> SaveImages(IFormFile image)
        //{

        //    var savePath = Path.Combine(_imagePath);
        //    if (!Directory.Exists(savePath))
        //    {
        //        Directory.CreateDirectory(savePath);
        //    }
        //    var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
        //    var fileName = Guid.NewGuid() + $"_{DateTime.Now.ToString("dd-MM-yy")}{mime}";

        //    using (var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create))
        //    {
        //        await image.CopyToAsync(fileStream);
        //    }
        //    return fileName;
        //} 
        #endregion

    }
}
