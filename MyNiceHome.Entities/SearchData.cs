using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class SearchData
    {
        public string Place { get; set; }
        public string FromDateInString { get; set; }
        public string ToDateInString { get; set; }
        public int NoOfPeople { get; set; }
    }
}
