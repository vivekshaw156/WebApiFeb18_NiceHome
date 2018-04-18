using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    public class MyNiceHomeContext:DbContext
    {
        public MyNiceHomeContext(): base("name=MyNiceHomeConnection")
        {

        }
        public DbSet<Host> HostDetails { get; set; }
        public DbSet<Traveller> TravellerDetails { get; set; }

        public DbSet<TravellerRating> TravellerRatings { get; set; }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyRating> PropertyRatings { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<PaymentMock> PaymentMocks { get; set; }

        public DbSet<PermanentBookingLog> PermanentBookingLogs { get; set; }
    }
}
