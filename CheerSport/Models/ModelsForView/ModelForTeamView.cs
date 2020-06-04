using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models.ModelsForView
{
    public class ModelForTeamView
    {
        public List<Club> allClub { get; set; }
        public Team selectTeam { get; set; }
    }
}
