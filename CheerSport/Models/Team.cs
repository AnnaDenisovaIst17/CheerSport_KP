using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }

        public int Clubid { get; set; }
        [ForeignKey("Clubid")]
        public virtual Club club { get; set; }
    }
}
