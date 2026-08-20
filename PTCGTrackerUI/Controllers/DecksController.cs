using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTCGTrackerUI.Models;
using PTCGTrackerUI.ViewModels;

namespace PTCGTrackerUI.Controllers;

public class DecksController : Controller
{
    private readonly IDeckRepository _deckRepository;
    private readonly IDeckCardRepository _deckCardRepository;
    private readonly IUserRepository _userRepository;

    public DecksController(IDeckRepository deckRepository, IDeckCardRepository deckCardRepository, IUserRepository userRepository)
    {
        _deckRepository = deckRepository;
        _deckCardRepository = deckCardRepository;
        _userRepository = userRepository;
    }

    [HttpGet("/Decks/Deck/{id:int}")]
    public async Task<IActionResult> Deck(int id)
    {
        var deck = await _deckRepository.GetDeckById(id);
        var cards = await _deckCardRepository.GetDeckListByUser(id);
        var user = await _userRepository.GetUserById(deck.userId);

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
        await _deckRepository.LogDeckWin(id);

        return Json(new
        {
            success = true,
            message = "Logged Win"
        });
    }

    [HttpPost("/Decks/Deck/{id:int}/loss")]
    public async Task<IActionResult> DeckPostLoss(int id)
    {
        await _deckRepository.LogDeckLoss(id);

        return Json(new
        {
            success = true,
            message = "Logged Loss"
        });
    }
}
