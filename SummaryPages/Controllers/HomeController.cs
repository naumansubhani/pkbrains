using Microsoft.AspNetCore.Mvc;
using myAPI.Models;
using SummaryPages.Models;
using System.Diagnostics;

namespace SummaryPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseUri = "https://localhost:7043/WIP";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Order> orderlist = new List<Order>();
            client.BaseAddress = new Uri(baseUri);
            //var response = client.GetAsync(baseUri).Result;
            var response = client.GetAsync(baseUri);
            response.Wait();
            //response.EnsureSuccessStatusCode();
            var test = response.Result;
            /*test.EnsureSuccessStatusCode();*/

            var display = test.Content.ReadAsAsync<List<Order>>();
            orderlist = display.Result;
            return View(orderlist);
        
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
}
