﻿using Microsoft.AspNetCore.Identity;

namespace BlogApi.DomainLayer.Models
{
    public class User : IdentityUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateOnly dob { get; set; }
    }
}
