namespace ScratchCards.Models.Api.Game
{
    public class GameSpinResponse
    {
        public int[] WheelSignIds { get; set; }

        public ScratchCard[] ScratchCards { get; set; }

        public int Prize { get; set; }

        public class ScratchCard
        {
            public int[] SignIds { get; set; }

            public int Prize { get; set; }
        }
    }
}
