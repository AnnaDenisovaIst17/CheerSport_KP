using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models.ModelsForView
{
    public class ModelForClubView
    {
        public List<Club> allClubs { get; set; }
        public List<Trainer> trainerOnClub { get; set; }
        public List<Team> teamOnClub { get; set; }
        public List<Sportsmen> sportsmenOnClub { get; set; }
        public int selectClub { get; set; }
    }
}
