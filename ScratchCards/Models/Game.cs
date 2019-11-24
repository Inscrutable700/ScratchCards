using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SignsNumberOnWheel { get; set; }

        public int SignsNumberOnScratchCard { get; set; }

        public ICollection<Sign> Signs { get; set; }

        public ICollection<MatchingConfiguration> MatchingConfigurations { get; set; }
    }
}
