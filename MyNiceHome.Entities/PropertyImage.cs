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
    /// PropertyImage Class
    /// </summary>
    public class PropertyImage
    {
        #region Properties of PropertyImage Class
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [ForeignKey("Property")]
        public string PID { get; set; }

        public byte[] Image { get; set; }

        public Property Property { get; set; }
        #endregion
    }
}
