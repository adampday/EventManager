using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager3.Models
{
    public class Event
    {
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string location { get; set; }
        public string genre { get; set; }
        // new change
    }
}
