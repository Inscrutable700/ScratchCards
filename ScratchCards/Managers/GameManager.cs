using ScratchCards.Dto;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchCards.Managers
{
    public class GameManager : IGameManager
    {
        private readonly ICachingManager cachingManager;

        private readonly IGameRepository gameRepository;

        public GameManager(ICachingManager cachingManager, IGameRepository gameRepository)
        {
            this.cachingManager = cachingManager;
            this.gameRepository = gameRepository;
        }

        public GameSpinDto Spin(int gameId, int bet, int numberOfScratchCards)
        {
            GameSpinDto result = new GameSpinDto();

            GameConfigurationDto gameConfiguration = this.GetGameConfiguration(gameId);

            if (gameConfiguration != null)
            {
                Random randomizer = new Random();

                result.WheelSignIds = new int[gameConfiguration.SignsNumberOnWheel];

                List<SignDto> signs = gameConfiguration.Signs.ToList();

                for (int i = 0; i < gameConfiguration.SignsNumberOnWheel; i++)
                {
                    int randomIndex = randomizer.Next(0, signs.Count - 1);
                    result.WheelSignIds[i] = signs[randomIndex].Id;
                    signs.RemoveAt(randomIndex);
                }

                result.ScratchCards = new ScratchCardDto[numberOfScratchCards];
                for (int i = 0; i < numberOfScratchCards; i++)
                {
                    ScratchCardDto scratchCard = new ScratchCardDto
                    {
                        SignIds = new int[gameConfiguration.SignsNumberOnScratchCard]
                    };

                    for (int j = 0; j < gameConfiguration.SignsNumberOnScratchCard; j++)
                    {
                        int randomIndex = randomizer.Next(0, gameConfiguration.Signs.Length - 1);
                        scratchCard.SignIds[j] = gameConfiguration.Signs[randomIndex].Id;
                    }

                    scratchCard.Prize = this.CalculatePrize(bet, result.WheelSignIds, scratchCard.SignIds, gameConfiguration.MatchingConfigurations);
                    result.ScratchCards[i] = scratchCard;
                }

                result.Prize = result.ScratchCards.Sum(sc => sc.Prize);
            }

            return result;
        }

        private int CalculatePrize(int bet, int[] wheelSignIds, int[] scratchCardSignIds,
            MatchingConfigurationDto[] matchingConfigurations)
        {
            int numberOfMatching = scratchCardSignIds.Where(scs => wheelSignIds.Contains(scs))
                .Count();


            MatchingConfigurationDto configuaration = matchingConfigurations
                .FirstOrDefault(mc => mc.MatchingSignsCount == numberOfMatching);

            int factor = configuaration == null ? 1 : configuaration.Factor;

            return bet * factor;
        }

        public GameConfigurationDto GetGameConfiguration(int gameId)
        {
            GameConfigurationDto gameConfiguration = this.cachingManager.GetGameConfiguration(gameId);

            if (gameConfiguration == null)
            {
                Game game = this.gameRepository.GetGame(gameId);

                if (game != null)
                {
                    gameConfiguration = new GameConfigurationDto
                    {
                        Id = game.Id,
                        Name = game.Name,
                        SignsNumberOnScratchCard = game.SignsNumberOnScratchCard,
                        SignsNumberOnWheel = game.SignsNumberOnWheel,
                        Signs = game.Signs.Select(s => new SignDto
                        {
                            Id = s.Id,
                            ImageUrl = s.ImageUrl,
                            Name = s.Name
                        }).ToArray(),
                        MatchingConfigurations = game.MatchingConfigurations.Select(mc => new MatchingConfigurationDto
                        {
                            Factor = mc.Factor,
                            Id = mc.Id,
                            MatchingSignsCount = mc.MatchingSignsCount
                        }).ToArray()
                    };

                    this.cachingManager.SetGameConfiguration(gameId, gameConfiguration);
                }
            }

            return gameConfiguration;
        }
    }
}