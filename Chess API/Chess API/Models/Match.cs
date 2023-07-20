namespace Chess_API.Models;

public class Match
{
    public int MatchId { get; set; }
    public int Player1Id { get; set; }
    public int Player2Id { get; set; }  
    public int PlayerWinnerId { get; set; }
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; }
}
