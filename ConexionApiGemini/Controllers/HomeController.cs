using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConexionApiGemini.Models;
using ConexionApiGemini.Repository;
using ConexionApiGemini.Interface;

namespace ConexionApiGemini.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IChatBotService _chatBotService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _chatBotService = new GeminiRepository();
    }

    public async Task <IActionResult> Index()
    {
        
        string answer = await _chatBotService.GetChatBotResponse("¿Dame un resumen de la pelicula coco?");
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
