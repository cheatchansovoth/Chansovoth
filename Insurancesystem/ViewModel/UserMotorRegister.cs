using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Insurancesystem.ViewModel
{
    public class UserMotorRegister
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Repassword { get; set; }
        [Required]
        public string ModeOfUse { get; set; }
        [Required]
        public int MotorRegisternumber { get; set; }
        [Required]
        public double MotorValue { get; set; }
    }
}