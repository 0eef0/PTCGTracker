using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AccountController : Controller
{
    [HttpPost]
    public IActionResult DiscordLogin()
    {
        var redirectUrl = Url.Action(
            "DiscordResponse",
            "Account");

        var properties = new AuthenticationProperties
        {
            RedirectUri = redirectUrl
        };

        return Challenge(
            properties,
            "Discord");
    }

    [HttpGet]
    public async Task<IActionResult> DiscordResponse()
    {
        var result = await HttpContext.AuthenticateAsync("Discord");

        if (!result.Succeeded)
        {
            return RedirectToAction("Login");
        }

        var username = result.Principal?.Identity?.Name;

        Console.WriteLine($"Discord username: {username}");

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            result.Principal!);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

}