namespace RockPaperScissors.Logic
{
    public interface ILogic
    {
        T GetById<T>(int id) where T : class;
    }
}
