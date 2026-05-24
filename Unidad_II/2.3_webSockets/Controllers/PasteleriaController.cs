
using Microsoft.AspNetCore.Mvc;
namespace _2._3_webSockets.Controllers;

public class PasteleriaController : Controller
{
    public IActionResult Clientes()
    {
        return View();
    }
    private readonly ILogger<PasteleriaController> _logger;

    public PasteleriaController(ILogger<PasteleriaController> logger)
    {
        _logger = logger;
    }
    public IActionResult Proveedores()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

}