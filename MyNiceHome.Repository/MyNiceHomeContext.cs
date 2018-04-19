using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    /// <summary>
    /// MyNiceHomeContext Class
    /// </summary>
    public class MyNiceHomeContext:DbContext
    {
        /// <summary>
        /// Constructor for MyNiceHomeContext
        /// </summary>
        public MyNiceHomeContext(): base("name=MyNiceHomeConnection")
        {

        }

        #region MyNiceHomeContext Properties

        /// <summary>
        /// HostDetails Property
        /// </summary>
        public DbSet<Host> HostDetails { get; set; }

        /// <summary>
        /// Traveller Details Property
        /// </summary>
        public DbSet<Traveller> TravellerDetails { get; set; }

        /// <summary>
        /// Traveller Ratings Property
        /// </summary>
        public DbSet<TravellerRating> TravellerRatings { get; set; }

        /// <summary>
        /// Property representing Properties
        /// </summary>
        public DbSet<Property> Properties { get; set; }

         /// <summary>
         /// PropertyImages Property
         /// </summary>
        public DbSet<PropertyImage> PropertyImages { get; set; }

        /// <summary>
        /// PropertyRatings Property
        /// </summary>
        public DbSet<PropertyRating> PropertyRatings { get; set; }

        /// <summary>
        /// PropertyTypes Property
        /// </summary>
        public DbSet<PropertyType> PropertyTypes { get; set; }

        /// <summary>
        /// PaymentMocks Property
        /// </summary>
        public DbSet<PaymentMock> PaymentMocks { get; set; }

        /// <summary>
        /// PermanentBookingLogs Property
        /// </summary>
        public DbSet<PermanentBookingLog> PermanentBookingLogs { get; set; }
        #endregion
    }
}
