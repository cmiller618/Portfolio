namespace Chess_API.Models;

public class PlayerStats
{
    public int PlayerProfileId { get; set; }
    public string PlayerName { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
}
