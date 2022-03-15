using System.ComponentModel.DataAnnotations;

namespace Helperland_Clone.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please enter E-mail address")]
        [EmailAddress(ErrorMessage = "Please enter Valid email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,16}$", ErrorMessage = "You must enter At least one upper case, one lower case, one digit and Minimum six and Maximum 16 in length")]
        public string Password { get; set; }
        public bool IsPersistant { get; set; }
    }
}
