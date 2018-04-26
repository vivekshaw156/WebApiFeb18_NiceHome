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
    /// Property Class
    /// </summary>
    public class Property
    {
        #region Properties of Property Class
        [Key]
        public string PID { get; set; }


        [ForeignKey("Host")]
        public string HID { get; set; }
        public string Location { get; set; }


        [ForeignKey("PropertyType")]
        public string Type_Id { get; set; }
        public int No_Of_Guests { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Desciption { get; set; }
        public bool IsDeleted { get; set; }

        public Host Host { get; set; }

        public List<PermanentBookingLog> PermanentBookingLogs { get; set; }

        public List<PaymentMock> PaymentMocks { get; set; }
        public PropertyType PropertyType { get; set; }

        public List<PropertyImage> PropertyImages { get; set; }

        public List<PropertyRating> PropertyRatings { get; set; }
        #endregion
    }
}
