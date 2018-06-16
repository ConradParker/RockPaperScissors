//using System;
//using System.Collections.Generic;
//using System.Linq;
//using RockPaperScissors.Data;
//using RockPaperScissors.Model;

//namespace RockPaperScissors.Service
//{
//    public class GameService : IGameService
//    {
//        private readonly RockPaperScissorsContext _context;

//        public GameService(RockPaperScissorsContext context)
//        {
//            _context = context;
//        }

//        public Game StartGame(int gamePlayCount, string playerOneType, string playerTwoType)
//        {
//            var game = new Game
//            {
//                GameDate = DateTime.Now,
//                GamePlayCount = gamePlayCount,
//                PlayerOneType = playerOneType,
//                PlayerTwoType = playerTwoType
//            };
//            _context.Games.Add(game);
//            _context.SaveChanges();

//            return game;
//        }
        
//        //public GameDto GetGame(int gameId)
//        //{
//        //    var game = _context.Set<Game>().Find(gameId);

//        //}

//        /// <summary>
//        /// Get a list of the string version of the computer players
//        /// </summary>
//        /// <returns>List of strings</returns>
//        public IEnumerable<string> GetComputerPlayers()
//        {
//            return GetComputerPlayerTypes().Select(p => p.ToString().Substring(24));
//        }
        
//        private static IEnumerable<Type> GetComputerPlayerTypes()
//        {
//            return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
//                    from assemblyType in domainAssembly.GetTypes()
//                    where typeof(Computer).IsAssignableFrom(assemblyType) && assemblyType != typeof(Computer)
//                    select assemblyType);
//        }
//    }
//}
