using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class SportCategory
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string orderNumber { get; set; }
        public string whoOrder { get; set; }
        public int SportRangid { get; set; }
        [ForeignKey("SportRangid")]
        public virtual SportRang sportRang { get; set; }
    }
}
