using E_Commerce.Application.Abstraction.IStorageService;
using E_Commerce.Application.RRModels.Appfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.StorageService
{
    public class StroageService(string webrootPath) : IStorageService
    {
        public string GetPhysicalPath() => Path.Combine(webrootPath, "Files");
        public string GetVirtualPath(string fileName) => "/Files/" + fileName;


        public string DeleteFile(string fileName)
        {
            var path = GetPhysicalPath();

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                var fullName = Path.Combine(path, fileName);
                if (File.Exists(fullName))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(fullName);
                    return "File Deleted Successfully";

                }
                
            }
            return "file is not deleted yet";
        }

        public async Task<(string, string)> SaveFileAsync(IFormFile file)
        {
            var path=GetPhysicalPath();
            var finalFileName = string.Concat(Guid.CreateVersion7(),Path.GetExtension(file.FileName));
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fullPath=Path.Combine(path, finalFileName);
            using var fs=new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(fs);
            var virtualPath = GetVirtualPath(finalFileName);
            return(virtualPath, finalFileName);
        }

        public async Task<AppFileSeparateResponse> SaveFilesAsync(IFormFileCollection files)
        {
            var path = GetPhysicalPath();
           
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileResponse = new AppFileSeparateResponse()
            {
                FileName = new List<string>(),
                FilePath = new List<string>(),
            };

            foreach (var file in files)
            {
                var finalFileName = string.Concat(Guid.CreateVersion7(), Path.GetExtension(file.FileName));

                var fullPath=Path.Combine(path, finalFileName);
                var fs=new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(fs);
                var virtualPath=GetVirtualPath(finalFileName);

                fileResponse.FilePath.Add(virtualPath);
                fileResponse.FileName.Add(finalFileName);
            }
            return fileResponse;
        }

       
    }
}
