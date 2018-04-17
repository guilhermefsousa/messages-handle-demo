using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Faturamento
{
    public class PedidoFeitoHandler : IHandleMessages<PedidoFeito>
    {
        public Task Handle(PedidoFeito message, IMessageHandlerContext context)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Evento PedidoFeito Recebido, PedidoId = {message.PedidoId} - Cobrando cartão de crédito...");

            var pedidoFaturado = new PedidoFaturado(message);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Disparando evento de PedidoFaturado, PedidoId: {message.PedidoId}");
            return context.Publish(pedidoFaturado);
        }
    }
}