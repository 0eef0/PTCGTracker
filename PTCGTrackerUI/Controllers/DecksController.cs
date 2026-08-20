using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTCGTrackerUI.Models;
using PTCGTrackerUI.ViewModels;

namespace PTCGTrackerUI.Controllers;

public class DecksController : Controller
{
    private readonly AppDbContext _context;

    public DecksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("/Decks/Deck/{id:int}")]
    public async Task<IActionResult> Deck(int id)
    {
        var deck = await _context.Decks
            .SingleAsync(d => d.deckId == id);

        var cards = await _context.DeckCards
            .Where(dc => dc.deckId == id)
            .ToListAsync();
        var user = await _context.AllUsers
            .SingleAsync(u => u.id == deck.userId);

        var deckList = new DeckListViewModel
        {
            Deck = deck,
            Cards = cards,
            User = user
        };

        return View(deckList);
    }

    [HttpPost("/Decks/Deck/{id:int}/win")]
    public async Task<IActionResult> DeckPostWin(int id)
    {
        Console.WriteLine("Test");

        var deck = await _context.Decks.SingleAsync(d => d.deckId == id);
        deck.wins++;
        _context.SaveChanges(); 

        return Json(new
        {
            success = true,
            message = "Logged Win"
        });
    }

    [HttpPost("/Decks/Deck/{id:int}/loss")]
    public async Task<IActionResult> DeckPostLoss(int id)
    {
        Console.WriteLine("Test");

        var deck = await _context.Decks.SingleAsync(d => d.deckId == id);
        deck.losses++;
        _context.SaveChanges(); 

        return Json(new
        {
            success = true,
            message = "Logged Loss"
        });
    }
}
