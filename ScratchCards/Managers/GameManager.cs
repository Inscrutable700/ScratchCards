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

            if (gameConfiguration.MaxNumberOfScratchCards < numberOfScratchCards)
            {
                throw new ArgumentException("Max number of scratch cards exceeded.");
            }

            if (gameConfiguration == null)
            {
                throw new ArgumentException("Game not found.");
            }

            this.SelectWheelSigns(ref result, gameConfiguration);

            this.SelectScratchCardsSigns(ref result, gameConfiguration, numberOfScratchCards);

            foreach (ScratchCardDto scratchCard in result.ScratchCards)
            {
                scratchCard.Factor = this.CalculatePrizeFactor(bet, result.WheelSignIds, scratchCard.SignIds, gameConfiguration);
                scratchCard.Prize = scratchCard.Factor * bet;
            }

            result.Prize = result.ScratchCards.Sum(sc => sc.Prize);
            
            return result;
        }

        private void SelectScratchCardsSigns(ref GameSpinDto gameSpin, GameConfigurationDto gameConfiguration, int numberOfScratchCards)
        {
            Random randomizer = new Random();

            gameSpin.ScratchCards = new ScratchCardDto[numberOfScratchCards];

            for (int i = 0; i < numberOfScratchCards; i++)
            {
                List<SignDto> signs = gameConfiguration.Signs.ToList();
                ScratchCardDto scratchCard = new ScratchCardDto
                {
                    SignIds = new int[gameConfiguration.SignsNumberOnScratchCard]
                };

                for (int j = 0; j < gameConfiguration.SignsNumberOnScratchCard; j++)
                {
                    int randomIndex = randomizer.Next(0, signs.Count);
                    scratchCard.SignIds[j] = signs[randomIndex].Id;

                    if (!gameConfiguration.ScratchCardSignsCanRepeat)
                    {
                        signs.RemoveAt(randomIndex);
                    }
                }

                gameSpin.ScratchCards[i] = scratchCard;
            }
        }

        private void SelectWheelSigns(ref GameSpinDto gameSpin, GameConfigurationDto gameConfiguration)
        {
            Random randomizer = new Random();

            gameSpin.WheelSignIds = new int[gameConfiguration.SignsNumberOnWheel];

            List<SignDto> signs = gameConfiguration.Signs.Where(s => !s.Special).ToList();

            for (int i = 0; i < gameConfiguration.SignsNumberOnWheel; i++)
            {
                int randomIndex = randomizer.Next(0, signs.Count);
                gameSpin.WheelSignIds[i] = signs[randomIndex].Id;
                signs.RemoveAt(randomIndex);
            }
        }

        private int CalculatePrizeFactor(int bet, int[] wheelSignIds, int[] scratchCardSignIds,
            GameConfigurationDto gameConfiguration)
        {
            //int numberOfMatching = scratchCardSignIds.Where(scs => wheelSignIds.Contains(scs))
            //    .Count();

            int numberOfMatching = scratchCardSignIds.Intersect(wheelSignIds).Count();

            int[] specialSignIds = gameConfiguration.Signs.Where(s => s.Special)
                .Select(s => s.Id)
                .ToArray();

            if (gameConfiguration.UseJokerFeature && specialSignIds.Length > 0)
            {
                numberOfMatching += scratchCardSignIds.Intersect(specialSignIds).Count();
            }

            MatchingConfigurationDto configuaration = gameConfiguration.MatchingConfigurations
                .FirstOrDefault(mc => mc.MatchingSignsCount == numberOfMatching);

            int factor = configuaration == null ? 1 : configuaration.Factor;

            return factor;
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
                        UseJokerFeature = game.UseJokerFeature,
                        MaxNumberOfScratchCards = game.MaxNumberOfScratchCards,
                        ScratchCardSignsCanRepeat = game.ScratchCardSignsCanRepeat,
                        Signs = game.Signs.Select(s => new SignDto
                        {
                            Id = s.Id,
                            ImageUrl = s.ImageUrl,
                            Name = s.Name,
                            Special = s.Special
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