using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Interfaces.Repository
{
    public interface IGameRepository
    {
        Game GetGame(int gameId);
    }
}
