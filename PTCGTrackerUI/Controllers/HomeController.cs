using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTCGTrackerUI.Models;
using PTCGTrackerUI.ViewModels;

namespace PTCGTrackerUI.Controllers;

public class HomeController : Controller
{
    private readonly IDeckRepository _deckRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDeckCardRepository _deckCardRepository;

    public HomeController(IDeckRepository deckRepository, IUserRepository userRepository, IDeckCardRepository deckCardRepository)
    {
        _deckRepository = deckRepository;
        _userRepository = userRepository;
        _deckCardRepository = deckCardRepository;
    }

    public async Task<IActionResult> Index()
    {
        UserModel user;
        List<DeckModel> decks;
        bool isLoggedIn = false;

        if(User.Identity?.IsAuthenticated == true)
        {
            user = await _userRepository.GetUserByName(User.Identity?.Name);
            decks = await _deckRepository.GetAllDecksByUser(user.id);
            isLoggedIn = true;
        } else
        {
            user = new();
            decks = new();
        }


        var topDecks = await _deckRepository.GetAllDecksSorted();

        foreach(var deck in topDecks)
        {
            deck.thumbnailCard = await _deckCardRepository.GetCardById(deck.thumbnailid);
            deck.owner = await _userRepository.GetUserById(deck.userId);
        }

        UserDeckViewModel userDeckViewModel = new UserDeckViewModel
        {
            user = user,
            decks = decks,
            topDecks = topDecks,
            isLoggedIn = isLoggedIn
        };

        return View(userDeckViewModel);
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
