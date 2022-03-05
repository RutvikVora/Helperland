using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Clone.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public int AddressId { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Please Enter Valid Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Please Enter Valid Phone No")]
        public string Mobile { get; set; }

        [Required]
        public bool isDefault { get; set; }
    }
}
