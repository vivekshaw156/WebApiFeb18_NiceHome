using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Entities
{
    public class PropertyRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyRatingId { get; set; }


        [ForeignKey("Traveller")]
        public string TID { get; set; }

        [ForeignKey("Property")]
        public string PID { get; set; }

        public int Property_Rating { get; set; }
        public string Property_Feedback { get; set; }

        public Property Property { get; set; }
        public Traveller Traveller { get; set; }
    }
}
