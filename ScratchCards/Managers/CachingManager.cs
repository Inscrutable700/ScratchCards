using Microsoft.Extensions.Caching.Memory;
using ScratchCards.Dto;
using ScratchCards.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Managers
{
    public class CachingManager : ICachingManager
    {
        private readonly IMemoryCache memoryCache;

        private const string GameCacheKey = "Game_Configuration_{0}";

        public CachingManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public GameConfigurationDto GetGameConfiguration(int gameId)
        {
            string key = string.Format(CachingManager.GameCacheKey, gameId);

            this.memoryCache.TryGetValue<GameConfigurationDto>(key, out GameConfigurationDto result);

            return result;
        }

        public void SetGameConfiguration(int gameId, GameConfigurationDto gameConfiguration)
        {
            string key = string.Format(CachingManager.GameCacheKey, gameId);
            this.memoryCache.Set(key, gameConfiguration);
        }
    }
}
