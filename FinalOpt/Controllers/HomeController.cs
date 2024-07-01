using FinalOpt.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalOpt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITablingService _tablingService;

        public HomeController(ITablingService tablingService)
        {
            _tablingService = tablingService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
