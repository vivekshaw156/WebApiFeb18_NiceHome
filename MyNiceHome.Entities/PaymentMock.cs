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
    /// Payment Mock Class
    /// </summary>
    public class PaymentMock
    {
        #region Properties of Payment Mock Class
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MockId { get; set; }


        [ForeignKey("PermanentBookingLog")]
        public string BID { get; set; }

        [ForeignKey("Traveller")]
        public string TID { get; set; }

        [ForeignKey("Host")]
        public string HID { get; set; }

        [ForeignKey("Property")]
        public string PID { get; set; }

        public decimal Amount { get; set; }



        public virtual Host Host { get; set; }
        public virtual PermanentBookingLog PermanentBookingLog { get; set; }
        public virtual Property Property { get; set; }
        public virtual Traveller Traveller{get; set;}
        #endregion
    }
}
