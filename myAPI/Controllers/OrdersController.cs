using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/)")]
    /*[ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]*/
    public class OrdersController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public OrdersController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet]
        [Route("/WIP")]
        public IActionResult Index()
        {
            var orders  = _orderRepository.GetOrders().ToList();
            return Ok(orders);
        }

        [HttpGet]
        [Route("/WIP/{id}")]
        public IActionResult Index(long id)
        {
            var orders = _orderRepository.GetOrders(id);
            return Ok(orders);
        }

    }
}
