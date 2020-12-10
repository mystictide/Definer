using System.ComponentModel.DataAnnotations;

namespace Definer.Web.Models
{
    public class UsersView
    {
        [Required(ErrorMessage = "you're going to need a name.")]
        [System.Web.Mvc.Remote("CheckExistingUsername", "Account", HttpMethod = "POST", ErrorMessage = "that sounds familiar, uh... try again?")]
        public string Name { get; set; }
        [Required(ErrorMessage = "i can't believe you've done this.")]
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "your argument is invalid.")]
        [System.Web.Mvc.Remote("CheckExistingEmail", "Account", HttpMethod = "POST", ErrorMessage = "heard of this before. nice try.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "trust me, you need this.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "trust me, you need this.")]
        [Compare("Password", ErrorMessage = "I can't match that up, chief.")]
        public string ConfirmPassword { get; set; }
        public bool isTrue
        { get { return true; } }
        [Required]
        [Compare("isTrue", ErrorMessage = "we're not in an agreement now, are we?")]
        public bool EULA { get; set; }
        public bool RememberMe { get; set; }
    }
}