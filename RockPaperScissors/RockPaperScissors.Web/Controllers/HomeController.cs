using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RockPaperScissors.Dto.Enums;
using RockPaperScissors.Logic;
using RockPaperScissors.Model;
using RockPaperScissors.Web.Models;
using System;
using System.Diagnostics;

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
            var viewModel = _gameLogic.GetIndexView();
            return View(viewModel);
        }

        public IActionResult StartMatch(int computerTypeId)
        {
            // Create new players
            var humanPlayer = _gameLogic.CreatePlayer(new Human());
            var computerPlayer = CreateComputerPlayer(computerTypeId);

            // Create new game
            var gameCount = int.Parse(_configuration["AppSettings:GamePlays"]);
            
            // Fetch and return
            var matchView = _gameLogic.StartMatch(gameCount, humanPlayer, computerPlayer);
            return PartialView("_Match", matchView);
         }

        public IActionResult PlayGame(int gameItemId, int matchId)
        {
            // Figure out player choices
            var match = _gameLogic.GetMatch(matchId);
            var playerOneChoice = _gameLogic.GetById<GameItem>(gameItemId);
            var computerChoice = _gameLogic.GetComputerChoice(match.PlayerTwo);

            // Play game
            _gameLogic.PlayGame(match, playerOneChoice, computerChoice);

            // Return results
            var matchView = _gameLogic.GetMatchView(matchId);
            return PartialView("_Match", matchView);
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
