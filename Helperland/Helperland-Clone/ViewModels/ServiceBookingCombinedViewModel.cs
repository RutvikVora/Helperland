using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Helperland_Clone.ViewModels
{
    public class ServiceBookingCombinedViewModel
    {
        public PostalCodeViewModel postalCode { get; set; }

        public ScheduleServiceViewModel schedule { get; set; }

        public AddressViewModel address { get; set; }

        public int startTime { get; set; }

        public int totalamount { get; set; }

        public int totalservicetime { get; set; }

        public int extraservicetime { get; set; }

        public int basichrs { get; set; }
    }
}
