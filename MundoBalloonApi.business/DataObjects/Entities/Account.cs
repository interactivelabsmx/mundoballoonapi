﻿using System;

namespace MundoBalloonApi.business.DataObjects.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? CompoundId { get; set; }
        public int UserId { get; set; }
        public string? ProviderType { get; set; }
        public string? ProviderId { get; set; }
        public string? ProviderAccountId { get; set; }
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpires { get; set; }
    }
}