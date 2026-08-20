using PTCGTrackerUI.Models;

namespace PTCGTrackerUI.ViewModels;

public class DeckListViewModel
{
    public DeckModel Deck { get; set; } = new();
    public List<DeckCardModel> Cards { get; set; } = new();
    public UserModel User { get; set; } = new();
}