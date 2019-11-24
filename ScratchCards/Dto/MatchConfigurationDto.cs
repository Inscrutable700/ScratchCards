using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Dto
{
    public class MatchingConfigurationDto
    {
        public int Id { get; set; }

        public int MatchingSignsCount { get; set; }

        public int Factor { get; set; }
    }
}
