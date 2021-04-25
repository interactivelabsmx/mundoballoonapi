
namespace MundoBalloonApi.business.DTOs.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public int? UserId { get; set; }
        public string? ProcessorId { get; set; }
        public string? Picture { get; set; }
    }
}