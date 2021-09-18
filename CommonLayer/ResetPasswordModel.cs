using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
   public class ResetPasswordModel
    {

      
        
        
        public string Password { get; set; }

       
        [Display(Name="Confirm Password")]
        [Compare("Password",ErrorMessage="Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }

      


    }
}
