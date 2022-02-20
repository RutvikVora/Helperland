using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Clone.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Mobile { get; set; }

        public bool isDefault { get; set; }
    }
}
