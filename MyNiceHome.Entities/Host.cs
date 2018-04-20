using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    /// <summary>
    /// Host Entity
    /// </summary>
    public class Host
    {
        [Key]
        public string HID { get; set; }

        public string HostName { get; set; }
        public string HostCity { get; set; }

        public string HostEmail { get; set; }

        public string HostPhone { get; set; }

        public string HostPassword { get; set; }

        public byte[] HostProfile { get; set; }


        public virtual List<PaymentMock> PaymentMocks { get; set; }

        public virtual List<PermanentBookingLog> PermanentBookingLogs { get; set; }

        public virtual List<Property> Properties { get; set; }

        public virtual List<TravellerRating> TravellerRatings { get; set; }
    }
}
