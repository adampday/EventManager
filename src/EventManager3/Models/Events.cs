using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager3.Models
{
    public class Events
    {
        public int EventsID { get; set; }
        public string ArtistID { get; set; }
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Artist Name is required")]
        public string ArtistName { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }     
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        // new changesd
    }
}
