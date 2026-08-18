using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTCGTrackerUI.Models;
using PTCGTrackerUI.ViewModels;

namespace PTCGTrackerUI.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        int currentDeck = 1;
        var deck = await _context.Decks.SingleAsync(d => d.deckId == currentDeck);
        var cards = await _context.DeckCards.Where(dc => dc.deckId == currentDeck).ToListAsync();

        DeckListViewModel deckList = new DeckListViewModel
        {
            Deck = deck,
            Cards = cards
        };

        return View(deckList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
