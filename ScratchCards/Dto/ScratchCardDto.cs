using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Dto
{
    public class ScratchCardDto
    {
        public int[] SignIds { get; set; }

        public int Prize { get; set; }

        public int Factor { get; set; }
    }
}
