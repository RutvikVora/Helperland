using System.Collections.Generic;

namespace Helperland_Clone.ViewModels
{
    public class CombinedAllViewModels
    {
        public CustomerDetailsViewModel details { get; set; }
        public IEnumerable<CustomerDashboardViewModel> DashboardViewModel { get; set; }
        public IEnumerable<AddressViewModel> address { get; set; }
        public AddressViewModel editAdd { get; set; }

        public ChangePswViewModel changePsw { get; set; }
    }
}

