using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.RRModels.Appfile
{
    public class AppFileResponse:AppFileRequest
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool UpdateAt { get; set; }
    }
}
