using CarRental.Core.Models.TinTuc;
using Microsoft.AspNetCore.SignalR;

namespace CarRental.Controllers
{
    public class NotificationHub: Hub
    {
        public async Task SendTinTuc(TinTucModel tinTuc)
        {
            await Clients.All.SendAsync("ReceiveTinTuc", tinTuc);
        }
    }
}
