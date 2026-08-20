namespace PTCGTrackerUI.Models;

public interface IDeckCardRepository
{
    public Task<List<DeckCardModel>> GetDeckListByUser(int id);
    public Task<DeckCardModel> GetCardById(int id);
}