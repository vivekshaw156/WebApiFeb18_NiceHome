using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class Traveller
    {
        [Key]
        public string TID { get; set; }
        public string TravellerName { get; set; }
        public string TravellerCity { get; set; }

        public string TravellerEmail { get; set; }

        public string TravellerPhone { get; set; }
        public string TravellerPassword { get; set; }


        public byte[] TravellerProfile { get; set; }


        public List<PermanentBookingLog> PermanentBookingLogs { get; set; }

        public List<PaymentMock> PaymentMocks { get; set; }

        public List<PropertyRating> PropertyRatings { get; set; }

        public List<TravellerRating> TravellerRatings { get; set; }

    }
}
