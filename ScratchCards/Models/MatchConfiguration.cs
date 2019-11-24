using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Models
{
    public class MatchingConfiguration
    {
        public int Id { get; set; }

        public int MatchingSignsCount { get; set; }

        public int Factor { get; set; }

        public int GameId { get; set; } 

        public Game Game { get; set; }
    }
}
