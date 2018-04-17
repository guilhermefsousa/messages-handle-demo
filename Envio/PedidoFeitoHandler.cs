using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Envio
{
    public class PedidoFeitoHandler : IHandleMessages<PedidoFeito>
    {
        public Task Handle(PedidoFeito message, IMessageHandlerContext context)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Evento PedidoFeito Recebido, PedidoId = {message.PedidoId} - Aguardando Faturamento...");
            return Task.CompletedTask;
        }
    }
}