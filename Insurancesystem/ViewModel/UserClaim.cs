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
        public string Email { get; set; }
        public string Nature { get; set; }
        public string Location { get; set; }
        public System.DateTime Date { get; set; }
        public int UserID { get; set; }
    }
}