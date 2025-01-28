using PicPaySimplificado.Service.Interfaces;

namespace PicPaySimplificado.Service.Services
{
    public class NotificacaoService : INotificacaoService
    {
        public async Task SendNotification()
        {
            await Task.Delay(1000);
            Console.WriteLine("Cliente notificado.");
        }
    }
}
