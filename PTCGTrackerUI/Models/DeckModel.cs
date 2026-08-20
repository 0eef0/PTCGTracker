using System.ComponentModel.DataAnnotations.Schema;

namespace PTCGTrackerUI.Models;

public class DeckModel
{
    public int deckId { set; get; }
    public int userId { set; get; }
    public string name { set; get; } = "";
    public int wins { set; get; }
    public int losses { set; get; }
    public int version { set; get; }
    public int thumbnailid { set; get; }

    [NotMapped]
    public DeckCardModel thumbnailCard { set; get; } = new();
    [NotMapped]
    public UserModel owner { set; get; } = new();

    public void Deconstruct(out int DeckId, out int UserId, out string Name, out int Wins, out int Losses, out int Version)
    {
        DeckId = deckId;
        UserId = userId;
        Name = name;
        Wins = wins;
        Losses = losses;
        Version = version;
    }

}