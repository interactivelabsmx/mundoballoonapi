using System;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class Session : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
        public string SessionToken { get; set; }
        public string AccessToken { get; set; }
    }
}