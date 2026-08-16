namespace PTCGTrackerUI.Models;

public class DeckModel
{
    public string DeckList { get; set; } = "";
    public int wins { get; private set; } = 0;
    public int losses { get; private set; } = 0;
}