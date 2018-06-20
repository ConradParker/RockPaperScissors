using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Dto.Enums;
using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System;
using System.Linq;

namespace RockPaperScissors.Logic
{
    public class GameLogic : Logic, IGameLogic
    {
        #region Private Variables

        private IGameRepository _gameRepository;

        #endregion Private Variables

        #region Constructor(s)

        public GameLogic(IGameRepository gameRepository) : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }

        #endregion Constructor(s)

        #region Public Methods

        /// <summary>
        /// Find a Match by its key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Match  Object</returns>
        public Match GetMatch(int id)
        {
            return _gameRepository.GetMatch(id);
        }

        /// <summary>
        /// Get Index View Data
        /// </summary>
        /// <returns>IndexView Object</returns>
        public IndexView GetIndexView()
        {
            var computerPlayers = Enum.GetValues(typeof(PlayerType))
                .Cast<PlayerType>()
                .Where(p => p != PlayerType.Human)
                .ToList();

            var view = new IndexView
            {
                PlayerTypes = computerPlayers
            };
            return view;
        }

        /// <summary>
        /// Find a Game Play View Data by its key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PlayView Object</returns>
        public MatchView GetMatchView(int id)
        {
            var matchView = new MatchView
            {
                MatchData = _gameRepository.GetMatchDto(id),
                GameItems = _gameRepository.GetGameItemDtos()
            };

            return matchView;
        }

        /// <summary>
        /// Creates a game object in the repository and returns the Id
        /// </summary>
        /// <param name="gameCount">The number of plays allowed in this game</param>
        /// <param name="playerOne">The type of player</param>
        /// <param name="playerTwo">The type of player</param>
        /// <returns>id of the new Match</returns>
        public MatchView StartMatch(int gameCount, Player playerOne, Player playerTwo)
        {
            var match = new Match
            {
                MatchDate = DateTime.Now,
                GameCount = gameCount,
                PlayerOne = playerOne,
                PlayerTwo = playerTwo
            };
            _gameRepository.Create(match);
            return GetMatchView(match.Id);
        }

        /// <summary>
        /// Make a play during the game
        /// </summary>
        /// <param name="match">The match</param>
        /// <param name="playerOneChoice">The GameItem</param>
        /// <param name="playerTwoChoice">The GameItem</param>
        /// <returns>The updated Game Dto</returns>
        public MatchView PlayGame(Match match, GameItem playerOneChoice, GameItem playerTwoChoice)
        {
            // Check we have not exceeded the allowed number of plays per game
            if (match.Games.Count >= match.GameCount)
            {
                throw new NotSupportedException("Game play count exceeded");
            }

            // Get game result
            var result = CalculateGameResult(playerOneChoice, playerTwoChoice);

            // Add the game to the repo
            _gameRepository.AddGame(match, playerOneChoice, playerTwoChoice, result);

            // Check if we should complete the Match
            if (match.Games.Count >= match.GameCount)
            {
                _gameRepository.CompleteMatch(match, CalculateMatchResult(match));
            }

            return GetMatchView(match.Id);
        }
        
        public Player CreatePlayer(Player player)
        {
            player.DateAdded = DateTime.Now;   
            return _gameRepository.Create(player);
        }

        public GameItem GetComputerChoice(Player computer)
        {
            GameItem computerChoice = null;

            switch (computer.GetType().Name)
            {
                case nameof(Computer):
                    computerChoice = ChooseRandomItem();
                    break;
                case nameof(TacticalComputer):
                    computerChoice = ChooseTacticalItem(computer);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return computerChoice;
        }

        /// <summary>
        /// Work out the Game result based on the choices supplied
        /// </summary>
        /// <param name="playerOneChoice"></param>
        /// <param name="playerTwoChoice"></param>
        /// <returns>Result object</returns>
        public Result CalculateGameResult(GameItem playerOneChoice, GameItem playerTwoChoice)
        {
            var gameResult = ResultType.Draw;

            if (playerOneChoice != playerTwoChoice)
            {
                if (FirstBeatsSecond(playerOneChoice, playerTwoChoice))
                {
                    gameResult = ResultType.Player1Win;
                }
                else if (FirstBeatsSecond(playerTwoChoice, playerOneChoice))
                {
                    gameResult = ResultType.Player2Win;
                }
            }

            return _gameRepository.GetById<Result>((int)gameResult);
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
            var itemIndex = random.Next(gameItems.Count);
            return _gameRepository.GetById<GameItem>(itemIndex + 1);
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
        
        /// <summary>
        /// Check if the first supplied GameItem beats the second
        /// </summary>
        /// <param name="firstChoice"></param>
        /// <param name="secondChoice"></param>
        /// <returns>bool</returns>
        private bool FirstBeatsSecond(GameItem firstChoice, GameItem secondChoice)
        {
            var rules = _gameRepository.GetAll<Rule>().ToList();

            var playerOneBeatsThese = rules.Where(r => r.GameItemId == firstChoice.Id).Select(r => r.BeatsId);
            if (playerOneBeatsThese.Any(r => r == secondChoice.Id))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculate the match result
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private Result CalculateMatchResult(Match match)
        {
            var resultType = ResultType.Draw;

            var playerOneWinCount = match.Games.Count(game => game.Result.Id == (int)ResultType.Player1Win);
            var playerTwoWinCount = match.Games.Count(game => game.Result.Id == (int)ResultType.Player2Win);

            if (playerOneWinCount > playerTwoWinCount)
            {
                resultType = ResultType.Player1Win;
            }
            else if (playerTwoWinCount > playerOneWinCount)
            {
                resultType = ResultType.Player2Win;
            }

            return GetById<Result>((int)resultType);
        }
        
        #endregion Private Methods
    }
}
