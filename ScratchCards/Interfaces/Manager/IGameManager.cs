using ScratchCards.Dto;
using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Interfaces.Manager
{
    public interface IGameManager
    {
        GameSpinDto Spin(int gameId, int bet, int numberOfScratchCards);

        GameConfigurationDto GetGameConfiguration(int gameId);
    }
}
