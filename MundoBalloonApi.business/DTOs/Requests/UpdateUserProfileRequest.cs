namespace MundoBalloonApi.business.DTOs.Requests
{
    public class UpdateUserProfileRequest
    {
        public string? UserId { get; set; }
        public string? ProcessorId { get; set; }
        public string? Picture { get; set; }
    }
}