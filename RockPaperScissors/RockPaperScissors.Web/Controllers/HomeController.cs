using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RockPaperScissors.Data.Enums;
using RockPaperScissors.Logic;
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
            // Validate parameter
            if (id == null)
            {
                return NotFound();
            }

            // Create new players
            var humanPlayer = _gameLogic.CreatePlayer(new Human());
            var computerPlayer = CreateComputerPlayer(id.Value);

            // Create new game
            var gameCount = int.Parse(_configuration["AppSettings:GamePlays"]);
            var match = _gameLogic.StartMatch(gameCount, humanPlayer, computerPlayer);

            return View(match);
        }
        
        public IActionResult Play(int matchId, int playerOneItemId)
        {
            // Figure out computer's choice
            var match = _gameLogic.GetMatch(matchId);
            var computer = _gameLogic.GetById<Computer>(match.PlayerTwoId);
            var computerChoiceId = _gameLogic.GetComputerChoice(computer).Id;

            // Play game and return results
            match = _gameLogic.PlayGame(matchId, playerOneItemId, computerChoiceId);
            return PartialView("_MatchPlay", match);
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

        #region Private Methods

        private Player CreateComputerPlayer(int playerTypeId)
        {
            Player computerPlayer = null;
            var playerType = (PlayerType)playerTypeId;
            switch (playerType)
            {
                case PlayerType.Random:
                    computerPlayer = _gameLogic.CreatePlayer(new Computer());
                    break;
                case PlayerType.Tactical:
                    computerPlayer = _gameLogic.CreatePlayer(new TacticalComputer());
                    break;
                default:
                    throw new NotSupportedException();
            }

            return computerPlayer;
        }

        #endregion Private Methods
    }
}
