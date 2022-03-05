namespace Helperland_Clone.ViewModels
{
    public class CustomerDashboardViewModel
    {
        public int ServiceId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ServiceProvider { get; set; }
        public decimal SPRatings { get; set; }
        public string SPAvatar { get; set; }
        public decimal Duration { get; set; }
        public int Status { get; set; }
        public decimal TotalCost { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}

