namespace RockPaperScissors.Dto
{
    public class GamePlayDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string PlayerOneChoice { get; set; }
        public string PlayerTwoChoice { get; set; }
        public string Result { get; set; }
    }
}
