namespace ScratchCards.Models.Api.Game
{
    public class GetGameConfigResponse
    {
        public int SignsNumberOnWheel { get; set; }

        public int SignsNumberOnScratchCard { get; set; }

        public int MaxNumberOfScratchCards { get; set; }

        public bool ScratchCardSignsCanRepeat { get; set; }

        public bool UseJokerFeature { get; set; }

        public Sign[] Signs { get; set; }

        public class Sign
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string ImageUrl { get; set; }

            public bool Special { get; set; }
        }
    }
}
