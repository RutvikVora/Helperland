using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Helperland_Clone.ViewModels
{
    public class PostalCodeViewModel
    {
        [Required]
        //[RegularExpression(@"[0-9]+", ErrorMessage = "Please Enter Numbers")]
        [StringLength(6, ErrorMessage = "Please Enter Valid Postal Code")]
        public string zipCode { get; set; }
    }
}
