using E_commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static E_commerce.Domain.Enums.AppEnums;

namespace E_Commerce.Domain.Entities
{
    public class AppFile:BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public Guid EntityId { get; set; } 
        public AppModule AppModule { get; set; } 
    }
}
