using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.Models.ModelsForView
{
    public class ModelForTrainerView
    {
        public List<Club> allClub { get; set; }
        public Trainer selectTrainer { get; set; }
    }
}
