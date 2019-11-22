namespace ScratchCards.Models.Api.Sign
{
    public class GetSignsResponse
    {
        public Sign[] Signs { get; set; }

        public class Sign
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string ImageUrl { get; set; }
        }
    }
}
