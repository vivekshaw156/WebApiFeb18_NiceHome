using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class PropertyList
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public int PropertyRatings { get; set; }

    }
}
