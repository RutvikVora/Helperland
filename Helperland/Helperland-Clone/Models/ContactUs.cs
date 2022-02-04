﻿using System;
using System.Collections.Generic;

namespace Helperland_Clone.Models
{
    public partial class ContactUs
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string UploadFileName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string FileName { get; set; }
    }
}
