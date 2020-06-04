using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Competition
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string direction { get; set; }
        public int countMember { get; set; }

        public int UnionRKid { get; set; }
        [ForeignKey("UnionRKid")]
        public virtual UnionRK unionRK { get; set; }

        public virtual ICollection<JudgeCompetition> JudgeCompetition { get; set; } = new List<JudgeCompetition>();
        [NotMapped]
        public IEnumerable<Judge> Judges { get { return JudgeCompetition.Select((x) => x.judge); } }
    }
}