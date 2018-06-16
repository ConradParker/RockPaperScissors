using System;

namespace RockPaperScissors.Model
{
    public class Tactical : Computer
    {
        public override GameItem ChooseItem()
        {
            // Agree with business whether to check previuous games 
            // or just last play from current game and Return tactical item
            throw new NotImplementedException();
        }
    }
}
