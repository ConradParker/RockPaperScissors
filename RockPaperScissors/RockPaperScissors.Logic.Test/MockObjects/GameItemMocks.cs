using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Logic.Test.MockObjects
{
    public class GameItemMocks
    {        
        public static GameItem RockGameItem
        {
            get
            {
                return new GameItem { Id = 1, Name = "Rock" };
            }
        }

        public static GameItem PaperGameItem
        {
            get
            {
                return new GameItem { Id = 2, Name = "Paper" };
            }
        }
        public static GameItem ScissorsGameItem
        {
            get
            {
                return new GameItem { Id = 1, Name = "Scissors" };
            }
        }
    }
}
