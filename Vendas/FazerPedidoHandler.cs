using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Vendas
{
    //Manipulador de mensagens
    public class FazerPedidoHandler : IHandleMessages<FazerPedido>
    {
        private static ILog _log = LogManager.GetLogger<FazerPedidoHandler>();

        public Task Handle(FazerPedido message, IMessageHandlerContext context)
        {
            Console.WriteLine($"FazerPedido Recebido, PedidoId: {message.PedidoId}");
            return Task.CompletedTask;
        }
    }
}