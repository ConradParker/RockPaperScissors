using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Logic
{
    public class GameLogic : IGameLogic
    {
        #region Private Variables

        private IGameRepository _gameRepository;

        #endregion Private Variables

        #region Constructor(s)

        public GameLogic(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        #endregion Constructor(s)

        #region Public Methods

        /// <summary>
        /// Find a Match by its key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Match Data Transfer Object</returns>
        public MatchDto GetMatch(int id)
        {
            return _gameRepository.GetMatch(id);
        }

        /// <summary>
        /// Creates a game object in the repository and returns the Dto
        /// </summary>
        /// <param name="gameCount">The number of plays allowed in this game</param>
        /// <param name="playerOne">The type of player</param>
        /// <param name="playerTwo">The type of player</param>
        /// <returns>Game Data Transfer Object</returns>
        public MatchDto StartMatch(int gameCount, Player playerOne, Player playerTwo)
        {
            // Add new players to repo
            
            var match = new Match
            {
                MatchDate = DateTime.Now,
                GameCount = gameCount,
                PlayerOne = playerOne,
                PlayerTwo = playerTwo
            };
            _gameRepository.Create(match);
            return _gameRepository.GetMatch(match.Id);
        }

        /// <summary>
        /// Make a play during the game
        /// </summary>
        /// <param name="matchId">The Id of the match</param>
        /// <param name="playerOneChoiceId">The GameItem id</param>
        /// <param name="playerTwoChoiceId">The GameItem id</param>
        /// <returns>The updated Game Dto</returns>
        public MatchDto PlayGame(int matchId, int playerOneChoiceId, int playerTwoChoiceId)
        {
            var playerOneChoice = _gameRepository.GetById<GameItem>(playerOneChoiceId);
            var playerTwoChoice = _gameRepository.GetById<GameItem>(playerTwoChoiceId);

            _gameRepository.AddGame(matchId, playerOneChoice, playerTwoChoice);
            return GetMatch(matchId);
        }
        
        public Player CreatePlayer(Player player)
        {
            player.DateAdded = DateTime.Now;   
            return _gameRepository.Create(player);
        }

        public GameItem GetComputerChoice(int matchId)
        {
            // Get match data from repo
            var match = _gameRepository.GetMatch(matchId);
            var playerTwo = _gameRepository.GetById<Player>(match.PlayerTwoId);
            
            // Validate we have a computer
            if (!(playerTwo is Computer))
            {
                throw new NotSupportedException();
            }

            if(playerTwo.GetType() == typeof(TacticalComputer))
            {
                return ChooseTacticalItem(playerTwo);
            }

            return ChooseRandomItem();
        }

        #endregion Public Methods

        #region Private Methods
        
        /// <summary>
        /// Choose a random item from the list of supplied items
        /// </summary>
        /// <returns>GameItem object</returns>
        private GameItem ChooseRandomItem()
        {
            var random = new Random();
            var gameItems = _gameRepository.GetAll<GameItem>().ToList();
            var randomItemKey = random.Next(gameItems.Count);
            return gameItems[randomItemKey];
        }

        /// <summary>
        /// Choose a tactical item based on the players last choice
        /// </summary>
        /// <param name="player"></param>
        /// <returns>GameItem object</returns>
        private GameItem ChooseTacticalItem(Player player)
        {
            // Do we have the last choice
            var lastChoice = _gameRepository.GetPlayersLastChoice(player);
            if (lastChoice != null)
            {
                var nextChoiceId = _gameRepository.GetAll<Rule>()
                    .ToList()
                    .SingleOrDefault(r => r.BeatsId == lastChoice.Id).GameItemId;
                return _gameRepository.GetById<GameItem>(nextChoiceId);
            }

            return ChooseRandomItem();
        }

        #endregion Private Methods
    }
}
