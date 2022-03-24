using Helperland_Clone.Models;

namespace Helperland_Clone.ViewModels
{
    public class AdminModalViewModel
    {
        public ServiceRequestAddress address { get; set; }

        public int ServiceId { get; set; }

        public string Date { get; set; }


        //public DateTime ServiceStartDate { get; set; }


        public string StartTime { get; set; }


        public string WhyReschedule { get; set; }

        public string CallCenterNote { get; set; }
    }
}
