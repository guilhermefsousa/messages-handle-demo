using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Envio
{
    public class PedidoFeitoHandler : IHandleMessages<PedidoFeito>
    {
        private static ILog _log = LogManager.GetLogger<PedidoFeitoHandler>();

        public Task Handle(PedidoFeito message, IMessageHandlerContext context)
        {
            _log.Info($"PedidoFeito Recebido, PedidoId = {message.PedidoId} - Aguardando Faturamento...");
            return Task.CompletedTask;
        }
    }
}