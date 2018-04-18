using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class PropertyType
    {
        [Key]
        public string Type_Id { get; set; }
        public string Type { get; set; }



        public List<Property> Properties { get; set; }
    }
}
