﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.UserDto
{
    public class UpdateUserDto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateOnly dob { get; set; }
    }
}
