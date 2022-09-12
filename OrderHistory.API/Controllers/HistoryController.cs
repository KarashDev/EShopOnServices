using Microsoft.AspNetCore.Mvc;

namespace OrderHistory.API.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
