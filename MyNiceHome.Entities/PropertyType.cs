using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    /// <summary>
    /// PropertyType Class
    /// </summary>
    public class PropertyType
    {
        #region Properties of PropertyType Class
        [Key]
        public string Type_Id { get; set; }
        public string Type { get; set; }
        public List<Property> Properties { get; set; }
        #endregion
    }
}
