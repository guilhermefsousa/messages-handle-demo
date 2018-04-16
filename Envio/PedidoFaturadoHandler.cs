using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Envio
{
    public class PedidoFaturadoHandler : IHandleMessages<PedidoFaturado>
    {
        private static ILog _log = LogManager.GetLogger<PedidoFaturadoHandler>();

        public Task Handle(PedidoFaturado message, IMessageHandlerContext context)
        {
            _log.Info($"PedidoFaturado Recebido, PedidoId = {message.PedidoId}, preparando para envio...");
            return Task.CompletedTask;
        }
    }
}