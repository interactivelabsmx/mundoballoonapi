using System;

#nullable disable

namespace MundoBalloonApi.infrastructure.Data.Models
{
    public class VerificationRequest : BaseEntity
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}