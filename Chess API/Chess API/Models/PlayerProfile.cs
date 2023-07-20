namespace Chess_API.Models;

public class PlayerProfile
{
    public int ProfileId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public PlayerStats PlayerStats { get; set; }
}
