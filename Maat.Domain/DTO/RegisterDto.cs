﻿using Maat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Domain.DTO
{
    public class RegisterDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }
    }
}
