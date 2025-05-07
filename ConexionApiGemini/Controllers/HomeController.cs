using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConexionApiGemini.Models;
using ConexionApiGemini.Repository;

namespace ConexionApiGemini.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task <IActionResult> Index()
    {
        GeminiRepository repo = new GeminiRepository();
        string answer = await repo.GetChatBotResponse("¿Dame un resumen de la pelicula coco?");
        return View(answer);
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
