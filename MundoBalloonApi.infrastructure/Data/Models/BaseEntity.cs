using System;

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}