using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WiredBrain.Helpers;

namespace WiredBrain.Hubs
{
    [Authorize]
    public class CoffeeHub : Hub
    {
        private readonly OrderChecker orderChecker;

        public CoffeeHub(OrderChecker orderChecker)
        {
            this.orderChecker = orderChecker;
        }

        public async Task GetUpdateForOrder(int orderId)
        {
            //Context.User
            CheckResult result;
            do
            {
                result = orderChecker.GetUpdate(orderId);
                Thread.Sleep(1000);
                if (result.New)
                    await Clients.Caller.SendAsync("ReceiveOrderUpdate",
                        result.Update);
            } while (!result.Finished);
            await Clients.Caller.SendAsync("Finished");
        }

        //public override async Task OnConnectedAsync()
        //{
        //    var connectionId = Context.ConnectionId;
        //    //await Clients.Client(connectionId).SendAsync("NewOrder", order);

        //}
    }
}
