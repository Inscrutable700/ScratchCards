using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Dto
{
    public class GameConfigurationDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SignsNumberOnWheel { get; set; }

        public int SignsNumberOnScratchCard { get; set; }

        public SignDto[] Signs { get; set; }

        public MatchingConfigurationDto[] MatchingConfigurations { get; set; }
    }
}
