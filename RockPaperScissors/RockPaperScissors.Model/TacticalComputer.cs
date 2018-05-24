using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Model
{
    public class TacticalComputer : ComputerDecorator
    {
        public TacticalComputer(Computer computer) : base(computer)
        {
        }

        public override GameItem ChooseItem()
        {
            // TODO: Return tactical item
            return new GameItem();
        }
    }
}
