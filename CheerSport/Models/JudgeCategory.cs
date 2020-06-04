using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class JudgeCategory
    {
        public int id { get; set; }
        public string orderNumber { get; set; }
        public DateTime whenOrder { get; set; }
        public string whoOrder { get; set; }
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public virtual Category category { get; set; }
    }
}
