using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Model
{
    public class ComputerDecorator : Computer
    {
        private Computer _computer;

        protected ComputerDecorator(Computer computer)
        {
            _computer = computer;
        }

        public override GameItem ChooseItem()
        {
            return _computer.ChooseItem();
        }
    }
}
