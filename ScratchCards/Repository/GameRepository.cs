using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScratchCards.Data;
using ScratchCards.Interfaces;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Repository
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext context;

        public GameRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Route(""), HttpGet]
        public Game GetGame(int gameId)
        {
            return this.context.Games
                .Include(g => g.Signs)
                .Include(g => g.MatchingConfigurations)
                .FirstOrDefault(g => g.Id == gameId);

            //throw new NotImplementedException();
        }
    }
}
