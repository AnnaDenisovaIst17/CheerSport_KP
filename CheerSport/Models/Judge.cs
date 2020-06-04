using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class Judge
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string subjectRF { get; set; }
        public string city { get; set; }
        public DateTime beginJudge { get; set; }
        public DateTime dateBirth { get; set; }
        public string education { get; set; }
        public string email { get; set; }
        public string job { get; set; }
        public string address { get; set; }

        public int JudgeCategoryid { get; set; }
        [ForeignKey("JudgeCategoryid")]
        public virtual JudgeCategory judgeCategory { get; set; }

        public int UnionRKid { get; set; }
        [ForeignKey("UnionRKid")]
        public virtual UnionRK unionRK { get; set; }

        public virtual ICollection<JudgeCompetition> JudgeCompetition { get; set; } = new List<JudgeCompetition>();
        [NotMapped]
        public IEnumerable<Competition> Competitions { get { return JudgeCompetition.Select((x) => x.competition); } }

    }
}
