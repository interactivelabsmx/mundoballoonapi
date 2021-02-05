#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class UserProfile : BaseEntity
    {
        public int UserProfileId { get; set; }
        public int? UserId { get; set; }
        public string ProcessorId { get; set; }
        public string Picture { get; set; }

        public virtual User User { get; set; }
    }
}