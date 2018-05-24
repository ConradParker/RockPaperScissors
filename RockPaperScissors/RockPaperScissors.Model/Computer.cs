using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Model
{
    public class Computer : Player
    {
        public virtual GameItem ChooseItem()
        {
            // TODO: Get random item
            throw new NotImplementedException();
        }
    }
}
