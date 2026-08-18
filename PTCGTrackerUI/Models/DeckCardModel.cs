namespace PTCGTrackerUI.Models;

public class DeckCardModel
{
    public int cardId { set; get; }
    public int deckId { set; get; }
    public int qtylist { set; get; }
    public int qtydeck { set; get; }
    public string name { set; get; } = "";
    public string set { set; get; } = "";
    public string reg { set; get; } = "";
    public string type { set; get; } = "";
    public int setNumber { set; get; }

}