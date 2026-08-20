using Microsoft.EntityFrameworkCore;

namespace PTCGTrackerUI.Models;

public class DeckCardRepository : IDeckCardRepository
{
    private readonly AppDbContext _context;

    public DeckCardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DeckCardModel>> GetDeckListByUser(int id)
    {
        return await _context.DeckCards.Where(dc => dc.deckId == id).ToListAsync();
    }

    public async Task<DeckCardModel> GetCardById(int id)
    {
        return await _context.DeckCards.SingleAsync(c => c.cardId == id);
    }
}