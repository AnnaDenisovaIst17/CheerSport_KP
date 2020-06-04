using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models
{
    public class JudgeCompetition
    {

        public int id { get; set; }

        public int Judgeid { get; set; }

        [ForeignKey("Judgeid")]
        public virtual Judge judge { get; set; }

        public int JudgePositionid { get; set; }
        [ForeignKey("JudgePositionid")]
        public virtual JudgePosition judgePosition { get; set; }

        public int Competitionid { get; set; }
        [ForeignKey("Competitionid")]
        public virtual Competition competition { get; set; }
    }
}
