namespace PTCGTrackerUI.Models;

public class DeckSetModel
{
    public string reg { set; get; } = "";
    public int amt { set; get; }

    public DeckSetModel(string Reg, int Amt)
    {
        reg = Reg;
        amt = Amt;
    }
}