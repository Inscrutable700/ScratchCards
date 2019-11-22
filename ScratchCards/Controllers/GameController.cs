using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScratchCards.Interfaces;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;

namespace ScratchCards.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameManager signRepository;

        public GameController(IGameManager signRepository)
        {
            this.signRepository = signRepository;
        }

        public IActionResult Index()
        {
            Sign[] signs = this.signRepository.GetSigns();

            return View();
        }
    }
}