using System;
using System.Collections.Generic;
using System.Text;
using static E_commerce.Domain.Enums.AppEnums;

namespace E_Commerce.Application.RRModels.Appfile
{
    public class AppFileRequest
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public AppModule AppModule { get; set; }
        public Guid EntityId { get; set; }
    }
}
