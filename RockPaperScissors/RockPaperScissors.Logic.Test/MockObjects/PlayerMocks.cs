using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System;
using System.Linq;

namespace RockPaperScissors.Logic.Test.MockObjects
{
    // Mock some Rock, Paper, Scissors Match Data
    public class PlayerMocks
    {
        public static Player HumanPlayer
        {
            get
            {
                var humanPlayer = new Human
                {
                    Id = 1
                };

                return humanPlayer;
            }
        }
        public static Player Computer
        {
            get
            {
                var computerPlayer = new Computer
                {
                    Id = 2
                };

                return computerPlayer;
            }
        }
        public static Player TacticalPlayer
        {
            get
            {
                var tacticalPlayer = new TacticalComputer
                {
                    Id = 3
                };

                return tacticalPlayer;
            }
        }
    }
}