namespace PTCGTrackerUI.Models;

public class DeckModel
{
    public int deckId { set; get; }
    public int userId { set; get; }
    public string name { set; get; } = "";
    public int wins { set; get; }
    public int losses { set; get; }

}