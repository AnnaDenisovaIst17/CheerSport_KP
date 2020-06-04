using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Trainer
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime dateBirth { get; set; }
        public string phone { get; set; }
        public string job { get; set; }
        public string photo { get; set; }

        public int Clubid { get; set; }
        [ForeignKey("Clubid")]
        public virtual Club club { get; set; }
    }
}
