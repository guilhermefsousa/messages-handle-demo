using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Envio
{
    public class PedidoFaturadoHandler : IHandleMessages<PedidoFaturado>
    {
        public Task Handle(PedidoFaturado message, IMessageHandlerContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Evento PedidoFaturado Recebido, PedidoId = {message.PedidoId}, preparando para envio...");
            return Task.CompletedTask;
        }
    }
}