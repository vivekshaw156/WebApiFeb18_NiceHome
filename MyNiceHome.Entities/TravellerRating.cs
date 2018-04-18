using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class TravellerRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TravellerRatingId { get; set; }

        [ForeignKey("Host")]
        public string HID { get; set; }

        [ForeignKey("Traveller")]
        public string TID { get; set; }


        public int Traveller_Rating { get; set; }
        public string Traveller_Feedback { get; set; }

        public Host Host { get; set; }
        public Traveller Traveller { get; set; }
    }
}
