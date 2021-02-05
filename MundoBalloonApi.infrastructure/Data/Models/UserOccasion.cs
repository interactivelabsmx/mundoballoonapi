using System;
using System.Collections.Generic;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class UserOccasion : BaseEntity
    {
        public UserOccasion()
        {
            OccasionCarts = new HashSet<OccasionCart>();
        }

        public int UserOccasionId { get; set; }
        public int? UserId { get; set; }
        public string OccasionName { get; set; }
        public DateTime? OccasionDate { get; set; }
        public string OccasionDetails { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OccasionCart> OccasionCarts { get; set; }
    }
}