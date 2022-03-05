using System.ComponentModel.DataAnnotations;

namespace Helperland_Clone.ViewModels
{
    public class ChangePswViewModel
    {
        [Required(ErrorMessage = "Please enter old Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,16}$", ErrorMessage = "Please enter appropriate old password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,16}$", ErrorMessage = "You must enter At least one upper case, one lower case, one digit and Minimum six and Maximum 16 in length")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
