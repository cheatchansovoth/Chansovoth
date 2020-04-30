using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Insurancesystem.ViewModel
{
    public class UserClaim
    {

        [Key]
        public int ClaimID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Nature { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        public int UserID { get; set; }
    }
}