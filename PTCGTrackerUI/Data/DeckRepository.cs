using Microsoft.EntityFrameworkCore;

namespace PTCGTrackerUI.Models;

public class DeckRepository : IDeckRepository
{
    private readonly AppDbContext _context;

    public DeckRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DeckModel>> GetAllDecksSorted()
    {
        return await _context.Decks.OrderByDescending(d => (d.losses != 0) ? (Convert.ToDouble(d.wins) / d.losses) : d.wins).ToListAsync();
    }

    public async Task<List<DeckModel>> GetAllDecksByUser(int id)
    {
        return await _context.Decks.Where(d => d.userId == id).ToListAsync();
    }

    public async Task<DeckModel> GetDeckById(int id)
    {
        return await _context.Decks.SingleAsync(d => d.deckId == id);
    }

    public async Task LogDeckWin(int id)
    {
        var deck = await GetDeckById(id);
        deck.wins++;
        await _context.SaveChangesAsync();
    }

    public async Task LogDeckLoss(int id)
    {
        var deck = await GetDeckById(id);
        deck.losses++;
        await _context.SaveChangesAsync();
    }
}