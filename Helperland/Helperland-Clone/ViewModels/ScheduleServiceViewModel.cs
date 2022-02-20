using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Clone.ViewModels
{
    public class ScheduleServiceViewModel
    {
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm aa}")]
        public DateTime Time { get; set; }

        public float Duration { get; set; }

        public ExtraServiceViewModel extra { get; set; }

        public String Comments { get; set; }

        public bool havePet { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
