using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Sportsmen
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime dateBirth { get; set; }
        public string disciplineName { get; set; }
        public string address { get; set; }
        public DateTime datePay { get; set; }

        public int SportCategoryid { get; set; }
        [ForeignKey("SportCategoryid")]
        public virtual SportCategory sportCategory{ get; set; }

        public int Clubid { get; set; }
        [ForeignKey("Clubid")]
        public virtual Club club { get; set; }
    }
}
