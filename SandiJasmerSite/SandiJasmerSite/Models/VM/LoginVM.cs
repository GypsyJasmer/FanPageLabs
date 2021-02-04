
using System.ComponentModel.DataAnnotations;

namespace TheRockFanPage.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string Password { get; set; }

        //login from any page and allows us to go back to the pagewe where at when loggedin. 
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
