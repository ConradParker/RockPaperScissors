using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Model
{
    public class Rule
    {
        public int GameItemId { get; set; }
        public int BeatsId { get; set; }
        public string Reason { get; set; }
    }
}
