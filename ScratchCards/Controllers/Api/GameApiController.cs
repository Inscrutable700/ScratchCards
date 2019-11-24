using Microsoft.AspNetCore.Mvc;
using ScratchCards.Extensions;
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

        [HttpPost, Route("{gameId:int}")]
        public IActionResult Spin(int gameId, [FromForm] GameSpinRequest request)
        {
            if (request == null)
            {
                return this.BadRequest("Request data should be provided.");
            }

            int[] signIds = this.gameManager.Spin(gameId, request.Bet);

            GameSpinResponse response = new GameSpinResponse
            {
                SignIds = signIds
            };

            return this.Json(response);
        }
    }
}