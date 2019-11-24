using ScratchCards.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Interfaces.Manager
{
    public interface ICachingManager
    {
        public GameConfigurationDto GetGameConfiguration(int gameId);

        public void SetGameConfiguration(int gameId, GameConfigurationDto gameConfiguration);
    }
}
