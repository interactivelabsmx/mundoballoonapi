using System;
using System.Collections.Generic;

namespace MundoBalloonApi.business.DTOs.Models
{
    public class UserOccasion
    {
        public int UserOccasionId { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Details { get; set; }

        public virtual ICollection<OccasionCart>? Carts { get; set; }
    }
}