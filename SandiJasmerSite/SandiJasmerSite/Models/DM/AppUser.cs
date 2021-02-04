using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class AppUser : IdentityUser
    {
        //public int UserID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }

        /*[EmailAddress]
        [Required]
        public string Email { get; set;}
        */
    }
}


