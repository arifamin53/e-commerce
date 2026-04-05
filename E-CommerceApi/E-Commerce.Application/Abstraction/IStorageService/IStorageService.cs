using E_Commerce.Application.RRModels.Appfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Abstraction.IStorageService
{
    public interface IStorageService
    {
        public Task<(string, string)> SaveFileAsync(IFormFile file);
        public Task<AppFileSeparateResponse> SaveFilesAsync(IFormFileCollection files);
        public string DeleteFile(string fileName);
        
    }
}
