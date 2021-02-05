namespace MundoBalloonApi.business.Dtos
{
    public class UpdateUserProfileRequest
    {
        public string? UserId { get; set; }
        public string? ProcessorId { get; set; }
        public string? Picture { get; set; }
    }
}
