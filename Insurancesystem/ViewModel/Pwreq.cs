using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Insurancesystem.ViewModel
{
    public class Pwreq
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password doesnt match!!")]
        public string Repassword { get; set; }
    }
}