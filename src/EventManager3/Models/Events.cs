using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager3.Models
{
    public class Events
    {
        public int EventsID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Genre { get; set; }
        // new changesd
    }
}
