using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DbC.Contexts;
using ProniaUI.ViewModels;

namespace ProniaUI.Contorllers;

public class HomeController : Controller
{
    //private AppDbContext _context { get; }

    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM vm = new()
        {
            Sliders = await _context.Sliders.ToListAsync(),
            Services = await _context.Services.ToListAsync(),

        };
        return View(vm);
    }
}
