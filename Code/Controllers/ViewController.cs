using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Example.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers;

public class ViewController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly RoleManager<UserRole> _roleManager;

    private readonly SignInManager<UserStore> _signInManager;

    private readonly UserManager<UserStore> _userManager;

    public ViewController(RoleManager<UserRole> roleManager, UserManager<UserStore> userManager, ILogger<HomeController> logger, SignInManager<UserStore> signInManager)
    {
        _logger = logger;

        _signInManager = signInManager;

        _userManager = userManager;

        _roleManager = roleManager;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult GeneralAction()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> AsyncAction()
    {
        return RedirectToAction("Index", "Home");
    }

}
