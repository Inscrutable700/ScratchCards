using Microsoft.AspNetCore.Mvc;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Models.Api.Game;

namespace ScratchCards.Controllers.Api
{
    [Route("api/game")]
    [ApiController]
    public class GameApiController : ControllerBase
    {
        private readonly IGameManager gameManager;

        public GameApiController(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        [HttpPost, Route("")]
        public GameSpinResponse Spin()
        {
            int[] signIds = this.gameManager.Spin();

            GameSpinResponse response = new GameSpinResponse
            {
                SignIds = signIds
            };

            return response;
        }
    }
}