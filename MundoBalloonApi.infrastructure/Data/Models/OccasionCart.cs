using System.Collections.Generic;

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class OccasionCart : BaseEntity
    {
        public OccasionCart()
        {
            OcassionCartDetails = new HashSet<OcassionCartDetail>();
        }

        public int OccasionCartId { get; set; }
        public int UserOccasionId { get; set; }
        public string? OccasionCartDescription { get; set; }
        public string? Title { get; set; }
        public string? DropOffStage { get; set; }

        public virtual UserOccasion? UserOccasion { get; set; }
        public virtual ICollection<OcassionCartDetail> OcassionCartDetails { get; set; }
    }
}