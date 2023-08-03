﻿using Microsoft.AspNetCore.Identity;

namespace TrainOnline.Models
{
    public class CustomUser: IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}
