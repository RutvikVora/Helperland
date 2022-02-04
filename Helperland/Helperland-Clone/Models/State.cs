using System;
using System.Collections.Generic;

namespace Helperland_Clone.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
