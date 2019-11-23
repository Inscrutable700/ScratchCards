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
        public GameController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}