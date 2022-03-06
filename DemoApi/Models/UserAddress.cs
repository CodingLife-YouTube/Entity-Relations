﻿namespace DemoApi.Models
{
    public class UserAddress
    {
        public Guid Id { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public Guid? UserId { get; set; } //FK
        public User User { get; set; }


    }
}
