using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WiredBrain.Hubs;
using WiredBrain.Models;

namespace WiredBrain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly IHubContext<CoffeeHub> coffeeHub;

        public CoffeeController(IHubContext<CoffeeHub> coffeeHub)
        {
            this.coffeeHub = coffeeHub;
        }

        [HttpPost]
        public async Task<IActionResult> OrderCoffee([FromBody] Order order)
        {
            await coffeeHub.Clients.All.SendAsync("NewOrder", order);
            //Save order somewhere and get order id
            return Accepted(1); //return order id
        }
    }
}
