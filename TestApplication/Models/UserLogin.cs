﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Key]
        public int UserrId { get; set; }
    }
}
