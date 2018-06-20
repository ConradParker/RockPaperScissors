namespace RockPaperScissors.Dto.Query
{
    public class GameDto
    {
        public int Id { get; set; }
        public string PlayerOneChoice { get; set; }
        public string PlayerTwoChoice { get; set; }
        public string Result { get; set; }
        public int ResultId { get; set; }
    }
}
