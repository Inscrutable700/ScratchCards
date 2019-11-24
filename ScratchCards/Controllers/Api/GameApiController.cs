using Microsoft.AspNetCore.Mvc;
using ScratchCards.Dto;
using ScratchCards.Extensions;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Models.Api.Game;
using System.Linq;

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

            GameSpinDto res = this.gameManager.Spin(gameId, request.Bet, request.NumberOfScratchCards);

            GameSpinResponse response = new GameSpinResponse
            {
                Prize = res.Prize,
                WheelSignIds = res.WheelSignIds,
                ScratchCards = res.ScratchCards.Select(sc => new GameSpinResponse.ScratchCard
                {
                    Prize = sc.Prize,
                    SignIds = sc.SignIds
                }).ToArray()
            };

            return this.Json(response);
        }
    }
}