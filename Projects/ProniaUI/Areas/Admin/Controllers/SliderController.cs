using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Buisness.ViewModels.SliderViewModels;
using Pronia.Core.Entities;
using Pronia.DbC.Contexts;

namespace ProniaUI.Areas.Admin.Controllers;

[Area("Admin")]

public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webEnv;

    public SliderController(AppDbContext context,
                            IMapper mapper,
                            IWebHostEnvironment webEnv)
    {
        _context = context;
        _mapper = mapper;
        _webEnv = webEnv;
    }

    public IActionResult Index()
    {
        return View(_context.Sliders.AsNoTracking());
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
    public async Task<IActionResult> Details(int id)
    {
        Slider? slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        if (slider == null) return NotFound();
        return View(slider);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderPostVM slider)
    {
        if(!ModelState.IsValid) return View(slider);
        //if (slider.ImageUrl.Length / 1024 > 100)
        //{
        //    ModelState.AddModelError("ImageUrl", "normal bir sey qoy");
        //    return View(slider);
        //}
        if (!slider.ImageUrl.ContentType.Contains("image/"))
        {
            {
                ModelState.AddModelError("ImageUrl", "sekil sec sekil a tupoy");
                return View(slider);
            }
        }
        //string folderroot = Path.Combine(_webEnv.WebRootPath, "assets", "images", "slider", "slide-img");
        string filename = Path.Combine("assets", "images", "slider", "slide-img",Guid.NewGuid().ToString()+ slider.ImageUrl.FileName);
        string fileRoot = Path.Combine(_webEnv.WebRootPath, filename);

        using (FileStream fileStream = new FileStream(fileRoot, FileMode.Create))
        {
            await slider.ImageUrl.CopyToAsync(fileStream);
        }
 
        Slider newslider = _mapper.Map<Slider>(slider);
        newslider.ImageUrl = filename;
        await _context.Sliders.AddAsync(newslider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
