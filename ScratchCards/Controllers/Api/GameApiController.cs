using Microsoft.AspNetCore.Mvc;
using ScratchCards.Dto;
using ScratchCards.Extensions;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Models.Api.Game;
using System;
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

            IActionResult result = null;

            try
            {
                GameSpinDto res = this.gameManager.Spin(gameId, request.Bet, request.NumberOfScratchCards);

                GameSpinResponse response = new GameSpinResponse
                {
                    Prize = res.Prize,
                    WheelSignIds = res.WheelSignIds,
                    ScratchCards = res.ScratchCards.Select(sc => new GameSpinResponse.ScratchCard
                    {
                        Prize = sc.Prize,
                        SignIds = sc.SignIds,
                        Factor = sc.Factor
                    }).ToArray()
                };

                result = this.Ok(response);
            }
            catch (ArgumentException ex)
            {
                result = this.BadRequest(ex.Message);
            }
            
            return result;
        }

        [HttpGet, Route("{gameId:int}/config")]
        public IActionResult GetGameConfig(int gameId)
        {
            GameConfigurationDto gameConfiguration = this.gameManager.GetGameConfiguration(gameId);

            GetGameConfigResponse response = new GetGameConfigResponse
            {
                MaxNumberOfScratchCards = gameConfiguration.MaxNumberOfScratchCards,
                Signs = gameConfiguration.Signs.Select(s => new GetGameConfigResponse.Sign
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl,
                    Special = s.Special
                }).ToArray()
            };

            return this.Ok(response);
        }
    }
}