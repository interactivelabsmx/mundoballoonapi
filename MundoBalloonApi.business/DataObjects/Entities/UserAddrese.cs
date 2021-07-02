namespace MundoBalloonApi.business.DataObjects.Entities
{
    public class UserAddrese
    {
        public int UserAddresesId { get; set; }
        public int? UserId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zipcode { get; set; }
        public bool? IsBilling { get; set; }
        public bool? IsShipping { get; set; }
    }
}