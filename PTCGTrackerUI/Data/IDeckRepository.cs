namespace PTCGTrackerUI.Models;

public interface IDeckRepository
{
    Task<List<DeckModel>> GetAllDecksSorted();
    Task<List<DeckModel>> GetAllDecksByUser(int id);
    Task<DeckModel> GetDeckById(int id);
    Task LogDeckWin(int id);
    Task LogDeckLoss(int id);
}