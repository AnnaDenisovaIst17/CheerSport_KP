using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Club
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime datePay { get; set; }
        public string city { get; set; }

        public int UnionRKid { get; set; }
        [ForeignKey("UnionRKid")]
        public virtual UnionRK unionRK { get; set; }

    }
}
