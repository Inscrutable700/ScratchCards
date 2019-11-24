using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Dto
{
    public class GameSpinDto
    {
        public int[] WheelSignIds { get; set; }

        public ScratchCardDto[] ScratchCards { get; set; }

        public int Prize { get; set; }
    }
}
