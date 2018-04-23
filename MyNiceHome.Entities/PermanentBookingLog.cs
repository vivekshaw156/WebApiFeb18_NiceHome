using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    /// <summary>
    /// Permanent Booking Log Class
    /// </summary>
   public class PermanentBookingLog
    {
        #region Properties of PermanentBookingLog
        [Key]
        public string BID { get; set; }

        [ForeignKey("Host")]
        public string HID { get; set; }

        [ForeignKey("Traveller")]
        public string TID { get; set; }

        [ForeignKey("Property")]
        public string PID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }



        public Host Host { get; set; }

        public List<PaymentMock> PaymentMocks { get; set; }
        public Property Property { get; set; }
        public Traveller Traveller { get; set; }
        #endregion
    }
}
