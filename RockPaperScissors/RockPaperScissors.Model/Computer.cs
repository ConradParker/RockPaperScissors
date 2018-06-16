namespace RockPaperScissors.Model
{
    public abstract class Computer : Player
    {
        public abstract GameItem ChooseItem();
    }
}
