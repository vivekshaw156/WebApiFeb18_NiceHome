using MyNiceHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Repository
{
    public class PropertyRepositoryUtility : IPropertyRepositoryUtility
    {
        MyNiceHomeContext context;
        public PropertyRepositoryUtility()
        {
            context = new MyNiceHomeContext();
        }

        public List<Property> GetPropertyDetails(string place, string fromDate, string toDate, int people)
        {
            List<Property> propertyList = new List<Property>(); 
            string[] fromDatesSplit = fromDate.Split('-');
            DateTime fromNewDate = new DateTime(Convert.ToInt32(fromDatesSplit[0]), Convert.ToInt32(fromDatesSplit[1]), Convert.ToInt32(fromDatesSplit[2]));
            DateTime toNewDate = new DateTime(Convert.ToInt32(fromDatesSplit[0]), Convert.ToInt32(fromDatesSplit[1]), Convert.ToInt32(fromDatesSplit[2]));

            //var query = (from details in context.Properties
            //            join dates in context.PermanentBookingLogs
            //            on details.PID equals dates.PID
            //            join image in context.PropertyImages 
            //            on dates.PID equals image.PID
            //            join propertyRating in context.PropertyRatings
            //            on image.PID equals propertyRating.PID
            //            where details.Location == place &&
            //            details.No_Of_Guests >= 1 && details.No_Of_Guests <= 10
            //            select new { details.Location, details.Price, details.Desciption, image.Image, propertyRating.Property_Rating }).ToList();

            //var query = (from details in context.Properties
            //             where details.Location == place
            //             && details.No_Of_Guests <= people
            //             && details.IsDeleted == false
            //             select details).ToList()
            //             .Where(data => data.PermanentBookingLogs.Where(dates => dates.FromDate >= fromNewDate && dates.ToDate <= toNewDate));                         
            var query = context.Properties.Where(details => details.Location == place && details.No_Of_Guests <= people && details.IsDeleted == false
                        && details.PermanentBookingLogs
                        .Where(date=> date.FromDate.CompareTo(fromNewDate)>=0 && date.ToDate.CompareTo(toNewDate)<=0).Count()==1 );


            //foreach(var obj in query)
            //{
            //    PropertyList propertyListObject = new PropertyList()
            //    {
            //        Location=obj.Location,
            //        Description=obj.Desciption,
            //        Price=(float)obj.Price,
            //        Image=obj.Image,
            //        PropertyRatings=obj.Property_Rating
            //    };
            //    propertyList.Add(propertyListObject);
            //}
            //return query;
            return new List<Property>();
        }
    }
}
