using PTCGTrackerUI.Models;

namespace PTCGTrackerUI;

public class UserDeckViewModel
{
    public UserModel user { get; set; } = new();
    public List<DeckModel> decks { get; set; } = new();
}