using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RockPaperScissors.Logic;
using RockPaperScissors.Logic.Enums;
using RockPaperScissors.Model;
using RockPaperScissors.Web.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace RockPaperScissors.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Private Variables

        private readonly IGameLogic _gameLogic;
        private IConfiguration _configuration;

        #endregion Private Variables

        #region Constructor(s)

        public HomeController(IGameLogic gameLogic, IConfiguration configuration)
        {
            _gameLogic = gameLogic;
            _configuration = configuration;
        }

        #endregion Constructor(s)

        #region Public Methods

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Match(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Figure out players
            Player computerPlayer = null;
            var humanPlayer = _gameLogic.CreatePlayer(new Human());
            
            if (id.Value == 1)
            {
                computerPlayer = _gameLogic.CreatePlayer(new Computer());
            }
            else if (id.Value == 2)
            {
                computerPlayer = _gameLogic.CreatePlayer(new TacticalComputer());
            }

            var gameCount = int.Parse(_configuration["AppSettings:GamePlays"]);
            var match = _gameLogic.StartMatch(gameCount, humanPlayer, computerPlayer);
            
            return View(match);
        }

        [HttpPost]
        public IActionResult Play(int matchId, int playerOneItemId)
        {
            var match = _gameLogic.PlayGame(matchId, 1, _gameLogic.GetComputerChoice(matchId).Id);
            return PartialView("_GameList", match.Games);
        }

        public IActionResult PlayerSelect()
        {
            var computerPlayers = Enum.GetValues(typeof(PlayerType))
                .Cast<PlayerType>()
                .Where(p => p != PlayerType.Human)
                .ToList();
            return View(computerPlayers);
        }


        public IActionResult Todo()
        {
            return View();
        }

        public IActionResult Worklog()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion Public Methods
    }
}
