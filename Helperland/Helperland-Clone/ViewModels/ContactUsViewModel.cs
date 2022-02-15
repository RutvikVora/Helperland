using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Helperland_Clone.ViewModels
{
    public class ContactUsViewModel
    {
        #nullable disable

        [Required(ErrorMessage = "*Please Enter Your Name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "*Please Enter Your Surname")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "*Please Enter Your Email Address")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "*Enter Valid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Phone]
        [StringLength(10)]
        public string mono { get; set; }
        public string subject { get; set; }

        [Required(ErrorMessage = "*Please Enter Your Message")]
        public string msg { get; set; }

        #nullable enable
        public IFormFile? File { get; set; }
    }
}
