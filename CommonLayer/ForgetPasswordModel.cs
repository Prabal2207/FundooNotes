﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
   public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
